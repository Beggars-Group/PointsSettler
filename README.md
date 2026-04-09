# PointsSettler · 绩律·天衡

[![Version](https://img.shields.io/badge/version-2.6-blue)](https://github.com/Beggars-Group/PointsSettler/releases)
[![.NET](https://img.shields.io/badge/.NET-10.0-purple)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)
[![Website](https://img.shields.io/badge/官网-立即访问-brightgreen)](https://Beggars-Group.github.io/PointsSettler/)

**官网**：[https://Beggars-Group.github.io/PointsSettler/](https://Beggars-Group.github.io/PointsSettler/)

**绩律·天衡** 是一款面向教师、班主任及教务管理人员的学业进退评分辅助工具。  
只需输入学生的进退名次与组积分，程序即可按照自定义比率快速算出规范化的评比分值，并自动留存操作日志。

---

## ✨ v2.6 更新内容

- 优化输入解析逻辑，支持中文逗号与空格混合分隔。
- 增强日志记录，包含原始数据、总和及完整计算过程。
- 调整控制台输出格式，信息展示更加清晰。
- 修复非数字输入时的异常提示问题。

---

## 📦 下载

从 [Releases](https://github.com/Beggars-Group/PointsSettler/releases) 页面获取最新版本（v2.6）：

| 文件 | 说明 | 运行要求 |
|------|------|----------|
| `PointsSettler_v2.6_portable.zip` | 可移植便携版（无运行时） | Windows 10+，需安装 [.NET 10 Runtime](https://dotnet.microsoft.com/download/dotnet/10.0) |
| `PointsSettler_v2.6_setup.exe` | 安装版（无运行时） | Windows 10+，需安装 [.NET 10 Runtime](https://dotnet.microsoft.com/download/dotnet/10.0) |
| `PointsSettler_v2.6_with_runtime_x86.exe` | 独立自包含版（含运行时） | Windows 10+ (32位)，无需安装 .NET，开箱即用 |

> 💡 **提示**：前两个版本体积较小，适合已安装 .NET 10 运行时的用户；独立版包含运行时，解压或安装后即可直接运行。

---

## 🔧 使用方法

1. 启动程序，输入进退分计算比率（如 `1.0`）。
2. 输入组别名称及该组学生的进退名次（可用空格、英文逗号或中文逗号分隔，例如 `3, -2, 5, 0`）。
3. 输入该组的组积分。
4. 查看计算结果，可继续处理下一组或输入 `q` 退出。
5. 程序将在同目录下自动生成 `YYYYMMDD_HHMMSS.txt` 日志文件。

---

## 📝 计算逻辑

```
平均进退 = 进退名次总和 ÷ 人数
进退分   = 平均进退 × 比率
评比分   = 进退分 + 组积分
```

> 所有结果均保留两位小数。

---

## 📁 项目结构

```
PointsSettler/
├── Program.cs          # 主程序入口与业务逻辑
├── PointsSettler.csproj # 项目文件（.NET 10）
├── README.md
└── LICENSE
```

---

## 🔨 从源码构建

```bash
# 克隆仓库
git clone https://github.com/Beggars-Group/PointsSettler.git
cd PointsSettler

# 构建便携版（需要 .NET 10 SDK）
dotnet publish -c Release -o ./publish/portable

# 构建独立自包含版（win-x86）
dotnet publish -c Release -r win-x86 --self-contained true -o ./publish/standalone-x86
```

---

## 📄 许可证

本项目基于 [MIT License](LICENSE) 发布，允许自由使用、修改及分发。

---

## 🔗 相关链接

- **官网**：[https://Beggars-Group.github.io/PointsSettler/](https://Beggars-Group.github.io/PointsSettler/)
- **丐帮原站镜像**：[https://bggp.dpdns.org/1/pointssettler/](https://bggp.dpdns.org/1/pointssettler/)
- **研究院主页**：[https://bggp.dpdns.org/1/](https://bggp.dpdns.org/1/)
- **.NET 10 Runtime**：[https://dotnet.microsoft.com/download/dotnet/10.0](https://dotnet.microsoft.com/download/dotnet/10.0)

---

## 🙋 反馈与贡献

- 遇到问题或有功能建议？欢迎提交 [Issue](https://github.com/Beggars-Group/PointsSettler/issues)。
- 想要贡献代码？请先阅读贡献指南并 Fork 本仓库。

---

**让评分更简单，让数据更清晰——绩律·天衡**
