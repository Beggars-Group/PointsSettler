using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

// 显式启用可空引用类型检查（.NET 10 默认已启用，此处为清晰表明意图）
#nullable enable

Console.OutputEncoding = Encoding.UTF8;

// 消除重复分配数组警告：定义只创建一次的分隔符数组，之后作为参数传递给解析函数
char[] separators = [' ', ',', '，'];

// 日志收集器
var log = new List<string>
{
    $"============ 绩律·天衡-系统日志 {DateTime.Now:yyyy-MM-dd HH:mm:ss} ============"
};

Console.WriteLine("============ 绩律·天衡 ============");

double ratio = ReadPositiveDouble("请输入进退分比率：", "输入格式错误，请输入正数");

Console.WriteLine("\n请先输入组别名称，然后输入学生进退名次（空格或逗号分隔），输入 q 结束\n");

while (true)
{
    Console.Write("请输入组别名称（或输入 q 结束）：");
    string? groupNameInput = Console.ReadLine();
    string groupName = (groupNameInput?.Trim()) ?? string.Empty;

    if (string.IsNullOrEmpty(groupName))
        continue;
    if (groupName.Equals("q", StringComparison.OrdinalIgnoreCase))
        break;

    // 输入进退名次
    Console.Write($"请输入 {groupName} 组学生进退名次（用空格或逗号分隔）：");
    string? dataInput = Console.ReadLine();
    string input = (dataInput?.Trim()) ?? string.Empty;
    if (string.IsNullOrEmpty(input))
        continue;

    // 解析进退名次列表（传入预先创建的分隔符数组，避免重复分配）
    if (!TryParseNumbers(input, separators, out List<double> numbers, out string? parseError))
    {
        Console.WriteLine($"输入格式错误：{parseError}\n");
        continue;
    }

    if (numbers.Count == 0)
    {
        Console.WriteLine("未输入任何有效数据，请重新输入。\n");
        continue;
    }

    // 计算进退分
    var (avg, progressScore) = CalculateProgressScore(numbers, ratio);

    // 输入组积分
    double groupScore = ReadDouble($"请输入 {groupName} 组积分：", "输入格式错误，请输入数字");

    // 最终得分
    double finalScore = Math.Round(progressScore + groupScore, 2);

    // 控制台输出
    PrintGroupResult(groupName, numbers.Count, avg, progressScore, ratio, groupScore, finalScore);

    // 记录日志
    AppendGroupLog(log, groupName, numbers, avg, progressScore, ratio, groupScore, finalScore);
}

// 3. 保存日志文件
SaveLogFile(log);

Console.WriteLine("程序结束，按任意键退出...");
Console.ReadKey();

return; // 顶级语句标准结束标记
static double ReadPositiveDouble(string prompt, string errorMessage)
{
    while (true)
    {
        Console.Write(prompt);
        string? line = Console.ReadLine();
        string input = line?.Trim() ?? string.Empty;

        if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double value) && value >= 0)
            return value;
        Console.WriteLine(errorMessage + "\n");
    }
}
static double ReadDouble(string prompt, string errorMessage)
{
    while (true)
    {
        Console.Write(prompt);
        string? line = Console.ReadLine();
        string input = line?.Trim() ?? string.Empty;

        if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            return value;
        Console.WriteLine(errorMessage + "\n");
    }
}

static bool TryParseNumbers(string input, char[] separators, out List<double> numbers, out string? error)
{
    numbers = []; // C# 12 集合表达式，简化初始化
    error = null;

    var parts = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    foreach (string part in parts)
    {
        if (double.TryParse(part, NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
            numbers.Add(num);
        else
        {
            error = $"无法解析 \"{part}\" 为数字";
            return false;
        }
    }
    return true;
}

static (double average, double progressScore) CalculateProgressScore(List<double> numbers, double ratio)
{
    double sum = numbers.Sum();
    double avg = Math.Round(sum / numbers.Count, 2);
    double progressScore = Math.Round(avg * ratio, 2);
    return (avg, progressScore);
}

static void PrintGroupResult(string groupName, int count, double avg, double progressScore, double ratio, double groupScore, double finalScore)
{
    Console.WriteLine($"\n组别：{groupName}");
    Console.WriteLine($"人数：{count}");
    Console.WriteLine($"平均进退：{avg}");
    Console.WriteLine($"进退分（平均 × 比率 {ratio}）：{progressScore}");
    Console.WriteLine($"组积分：{groupScore}");
    Console.WriteLine($"最终得分：{finalScore}\n");
}

static void AppendGroupLog(List<string> log, string groupName, List<double> numbers, double avg, double progressScore, double ratio, double groupScore, double finalScore)
{
    log.Add($"组别：{groupName}");
    log.Add($"原始数据：{string.Join(", ", numbers)}");
    log.Add($"人数：{numbers.Count}");
    log.Add($"总和：{numbers.Sum()}");
    log.Add($"平均进退：{avg}");
    log.Add($"进退分：{progressScore} （平均 × 比率 {ratio}）");
    log.Add($"组积分：{groupScore}");
    log.Add($"最终得分：{finalScore}");
    log.Add(new string('-', 40));
}

static void SaveLogFile(List<string> log)
{
    if (log.Count > 1) // 至少有一行标题
    {
        string fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        File.WriteAllLines(fileName, log, Encoding.UTF8);
        Console.WriteLine($"\n日志已保存：{fileName}");
    }
    else
    {
        Console.WriteLine("\n没有数据，未生成日志。");
    }
}