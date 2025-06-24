# Setup Guide

This guide will help you set up the project on your local machine. Follow these steps in order.

## Prerequisites

Before you begin, ensure you have the following installed:

### Required Software

1. **.NET SDK** (Version 6.0 or later)
   - Download from: [.NET Downloads](https://dotnet.microsoft.com/download)
   - Verify installation: Open terminal and run `dotnet --version`

2. **Visual Studio 2022** (Recommended)
   - Community Edition is free
   - Download from: [Visual Studio Downloads](https://visualstudio.microsoft.com/downloads/)
   - Required Workloads:
     - .NET Desktop Development
     - Universal Windows Platform Development

3. **Git**
   - Latest version
   - Download from: [Git Downloads](https://git-scm.com/downloads)
   - Verify installation: Open terminal and run `git --version`

### Optional Tools

1. **Visual Studio Code**
   - Download from: [VS Code](https://code.visualstudio.com/)
   - Recommended Extensions:
     - C# Dev Kit
     - .NET Core Tools
     - NuGet Package Manager

## Installation Steps

### 1. Clone the Repository

```bash
# Open terminal and navigate to your desired directory
git clone https://github.com/Rakshit4045/DesignPrinciples.git
cd oop
```

### 2. Open the Project

#### Using Visual Studio 2022
1. Launch Visual Studio 2022
2. Click "Open a project or solution"
3. Navigate to `C#/DesignPrinciples/DesignPrinciples.sln`
4. Click "Open"

#### Using Visual Studio Code
1. Launch VS Code
2. Go to File > Open Folder
3. Select `C#/DesignPrinciples` folder

### 3. Build the Project

#### Using Visual Studio 2022
1. Right-click solution in Solution Explorer
2. Select "Restore NuGet Packages"
3. Press F6 or click Build > Build Solution

#### Using Command Line
```bash
cd C#/DesignPrinciples
dotnet restore
dotnet build
```

### 4. Verify Installation

Run the project:
- Visual Studio: Press F5 or click "Start"
- VS Code: Press F5
- Command line: `dotnet run`

You should see the console application running with example outputs.

## Troubleshooting

If you encounter issues:

1. **Build Errors**
   - Ensure .NET SDK is properly installed
   - Run `dotnet --version` to verify
   - Try cleaning and rebuilding the solution

2. **Missing Dependencies**
   - Right-click solution and select "Restore NuGet Packages"
   - Run `dotnet restore` from command line

3. **IDE Issues**
   - Verify all required workloads are installed in Visual Studio
   - Check VS Code extensions are properly installed

## Next Steps

1. Review the [Project Structure](project-structure.md)
2. Start with [Single Responsibility Principle](./srp.md)
3. Follow the examples in order of complexity 