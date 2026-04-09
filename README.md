# PointsSettler · 绩律·天衡

[![.NET](https://img.shields.io/badge/.NET-10.0-purple)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)
[![Website](https://img.shields.io/badge/官网-立即访问-brightgreen)](https://Beggars-Group.github.io/PointsSettler/)

**官网**：[https://Beggars-Group.github.io/PointsSettler/](https://Beggars-Group.github.io/PointsSettler/)

**绩律·天衡** 是一款面向教师、班主任及教务管理人员的学业进退评分辅助工具。  
只需输入学生的进退名次与组积分，程序即可按照自定义比率快速算出规范化的评比分值，并自动留存操作日志。

---

## 🎯 主要功能

- **灵活比率配置**：进退分计算比率自由设定，适配不同评分规则。
- **批量分组处理**：可连续处理多个班级/小组，数据互不干扰。
- **智能输入解析**：进退名次支持空格、英文逗号、中文逗号混合输入。
- **清晰结果展示**：实时显示人数、平均进退、进退分、组积分及最终评比分。
- **自动日志留存**：每次运行生成带时间戳的 `.txt` 日志，便于核对与归档。

---

## 📦 下载与安装

👉 **请前往 [Releases 最新版](https://github.com/Beggars-Group/PointsSettler/releases/latest) 下载。**

在 Releases 页面中提供了以下变体以满足不同需求：

- **便携版（无运行时）**：需自行安装 [.NET 10 Runtime](https://dotnet.microsoft.com/download/dotnet/10.0)
- **安装版（无运行时）**：需自行安装 [.NET 10 Runtime](https://dotnet.microsoft.com/download/dotnet/10.0)
- **独立自包含版（含运行时）**：无需额外安装 .NET，开箱即用

> 💡 **提示**：前两种版本体积较小，适合已安装 .NET 10 运行时的用户；独立版包含运行时，解压或安装后即可直接运行。

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
