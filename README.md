<!-- markdownlint-disable MD033 -->
# EvilBaschdi.Extensions

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg?style=for-the-badge)](LICENSE)
[![Target: .NET 10.0](https://img.shields.io/badge/.NET-10.0-512bd4.svg?style=for-the-badge&logo=dotnet)](Directory.Build.props)

Extensions and core infrastructure libraries for .NET applications, providing dependency injection utilities, logging helpers, and file-based/machine-and-user settings management.

---

## 📈 Quality & Activity

| Branch | Status & Activity |
| :--- | :--- |
| ![Main](https://img.shields.io/badge/branch-main-brightgreen?style=flat-square&logo=git&logoColor=white&color=c9ff00) | [![CodeFactor](https://www.codefactor.io/repository/github/evilbaschdi/EvilBaschdi.Extensions/badge/main?style=flat-square)](https://www.codefactor.io/repository/github/evilbaschdi/EvilBaschdi.Extensions/overview/main) ![Commit Activity Main](https://img.shields.io/github/commit-activity/m/evilbaschdi/EvilBaschdi.Extensions/main?style=flat-square) ![Last Commit Main](https://img.shields.io/github/last-commit/evilbaschdi/EvilBaschdi.Extensions/main?style=flat-square) |
| ![Develop](https://img.shields.io/badge/branch-develop-blue?style=flat-square&logo=git&logoColor=white&color=0080ff) | [![CodeFactor](https://www.codefactor.io/repository/github/evilbaschdi/EvilBaschdi.Extensions/badge/develop?style=flat-square)](https://www.codefactor.io/repository/github/evilbaschdi/EvilBaschdi.Extensions/overview/develop) ![Commit Activity Develop](https://img.shields.io/github/commit-activity/m/evilbaschdi/EvilBaschdi.Extensions/develop?style=flat-square) ![Last Commit Develop](https://img.shields.io/github/last-commit/evilbaschdi/EvilBaschdi.Extensions/develop?style=flat-square) |

---

## 📦 Packages in this Repository

| Package | Description | Sources |
| :--- | :--- | :--- |
| [`EvilBaschdi.Core.DependencyInjection`](src/EvilBaschdi.Core.DependencyInjection) | Generic host setup, service configurators, lifecycle handlers & startup execution. | [![MyGet](https://img.shields.io/badge/MyGet-gray?style=flat-square&logo=myget)](https://myget.org/feed/evilbaschdi/package/nuget/EvilBaschdi.Core.DependencyInjection) [![Codeberg](https://img.shields.io/badge/Codeberg-gray?style=flat-square&logo=codeberg)](https://codeberg.org/evilbaschdi/-/packages/nuget/EvilBaschdi.Core.DependencyInjection) |
| [`EvilBaschdi.Core.Logging`](src/EvilBaschdi.Core.Logging) | Logging utilities and extensions for `Microsoft.Extensions.Logging`. | [![MyGet](https://img.shields.io/badge/MyGet-gray?style=flat-square&logo=myget)](https://myget.org/feed/evilbaschdi/package/nuget/EvilBaschdi.Core.Logging) [![Codeberg](https://img.shields.io/badge/Codeberg-gray?style=flat-square&logo=codeberg)](https://codeberg.org/evilbaschdi/-/packages/nuget/EvilBaschdi.Core.Logging) |
| [`EvilBaschdi.Core.Settings`](src/EvilBaschdi.Core.Settings) | JSON settings management with machine/user isolation and writable settings support. | [![MyGet](https://img.shields.io/badge/MyGet-gray?style=flat-square&logo=myget)](https://myget.org/feed/evilbaschdi/package/nuget/EvilBaschdi.Core.Settings) [![Codeberg](https://img.shields.io/badge/Codeberg-gray?style=flat-square&logo=codeberg)](https://codeberg.org/evilbaschdi/-/packages/nuget/EvilBaschdi.Core.Settings) |

---

## 🚀 Package Feeds

All packages (Release and Preview builds) are published to **MyGet** and **Codeberg**. You only need to configure **one** of these feeds.

| Registry | Feed URL |
| :--- | :--- |
| **MyGet** | `https://www.myget.org/F/evilbaschdi/api/v3/index.json` |
| **Codeberg** | `https://codeberg.org/api/packages/evilbaschdi/nuget/index.json` |

### Add Feed via .NET CLI

Choose either MyGet or Codeberg:

```bash
# Option A: MyGet (recommended)
dotnet nuget add source https://www.myget.org/F/evilbaschdi/api/v3/index.json -n "EvilBaschdi MyGet"

# Option B: Codeberg
dotnet nuget add source https://codeberg.org/api/packages/evilbaschdi/nuget/index.json -n "EvilBaschdi Codeberg"
```

<details>
<summary><b>Sample <code>NuGet.Config</code> with Package Source Mapping</b></summary>

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
    <!-- Choose one of the following feeds: -->
    <add key="EvilBaschdi MyGet" value="https://www.myget.org/F/evilbaschdi/api/v3/index.json" />
    <!-- <add key="EvilBaschdi Codeberg" value="https://codeberg.org/api/packages/evilbaschdi/nuget/index.json" /> -->
  </packageSources>

  <packageSourceMapping>
    <packageSource key="nuget.org">
      <package pattern="*" />
    </packageSource>
    <packageSource key="EvilBaschdi MyGet">
      <package pattern="EvilBaschdi.*" />
    </packageSource>
    <!-- <packageSource key="EvilBaschdi Codeberg">
      <package pattern="EvilBaschdi.*" />
    </packageSource> -->
  </packageSourceMapping>
</configuration>
```

</details>

---

## 📥 Installation

Install any package via `dotnet add package`:

### Standard Release

```bash
dotnet add package EvilBaschdi.Core.DependencyInjection
dotnet add package EvilBaschdi.Core.Logging
dotnet add package EvilBaschdi.Core.Settings
```

### Preview Builds

```bash
dotnet add package EvilBaschdi.Core.DependencyInjection --prerelease
dotnet add package EvilBaschdi.Core.Logging --prerelease
dotnet add package EvilBaschdi.Core.Settings --prerelease
```
