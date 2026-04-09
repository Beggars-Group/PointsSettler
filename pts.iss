; 绩律·天衡 v2.6 安装脚本
; 由 Inno Setup 生成，丐帮集团第一院™ 发行
; 官网: https://bggp.dpdns.org/1/pointssettler/

#define MyAppName "绩律·天衡"
#define MyAppVersion "2.6"
#define MyAppPublisher "丐帮集团第一院·物理版象棋开发与研究院™"
#define MyAppURL "https://bggp.dpdns.org/1/pointssettler/"
#define MyAppExeName "绩律·天衡.exe"

[Setup]
; 唯一应用程序标识符（已生成新 GUID）
AppId={{A8F6C2D3-4E1B-4F9A-8C2D-7B3A5F1E9D6C}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName=D:\Program Files\bggp\1\pointssettler
UninstallDisplayIcon={app}\{#MyAppExeName}
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
DisableProgramGroupPage=yes
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=C:\Users\鸿合HiteVision\OneDrive\桌面
OutputBaseFilename=PointsSettler_Setup_v2.6
SetupIconFile=C:\Users\鸿合HiteVision\OneDrive\文档\dec.ico
SolidCompression=yes
WizardStyle=modern dynamic windows11

[Languages]
Name: "chinesesimp"; MessagesFile: "compiler:Default.isl"
Name: "chinesetraditional"; MessagesFile: "compiler:Languages\ChineseTraditional.isl"
Name: "english"; MessagesFile: "compiler:Languages\English.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; 主程序与所有依赖文件（从打包文件夹复制）
Source: "C:\Users\鸿合HiteVision\OneDrive\桌面\a\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent