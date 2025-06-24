# Project Structure

This document explains the organization of the DesignPrinciples project and how different software design principles are implemented in C#.

## Directory Structure

```
C#/DesignPrinciples/
├── DesignPrinciples.sln                      # Solution file
├── DesignPrinciples/                         # Main project folder
│   ├── DesignPrinciples.csproj               # Project configuration file
│   └── Program.cs                            # Entry point of the application
├── OOP_Basics/                               # (Reference) OOP learning project
│   └── ...                                   # OOP concept examples
├── SRP/                                      # Single Responsibility Principle
│   ├── Program.cs                            # SRP demo entry point
│   ├── SRP.csproj                            # SRP project file
│   ├── Enums/                                # Supporting enums
│   │   └── LeaveType.cs
│   ├── Interfaces/                           # Interfaces for SRP
│   │   ├── ILeaveManager.cs
│   │   └── ISalaryCalculator.cs
│   ├── Models/                               # Data models
│   │   ├── ContractEmployee.cs
│   │   ├── Employee.cs
│   │   ├── LeaveBalance.cs
│   │   ├── LeaveRequest.cs
│   │   ├── PermanentEmployee.cs
│   │   └── SalaryDetails.cs
│   └── Services/                             # Service implementations
│       ├── LeaveManager.cs
│       └── SalaryCalculator.cs
└── docs/                                     # Documentation
    └── ...
```

## Code Organization

### Main Project
- Location: `DesignPrinciples/`
- Purpose: Entry point and shared resources for design principles demos
- Files:
  - `Program.cs`: Main entry point
  - `DesignPrinciples.csproj`: Project configuration

### OOP_Basics (Reference)
- Location: `OOP_Basics/`
- Purpose: Contains foundational OOP concept examples for reference
- Files: Examples of encapsulation, abstraction, polymorphism, inheritance, and interfaces

### Single Responsibility Principle (SRP)
- Location: `SRP/`
- Purpose: Demonstrates the Single Responsibility Principle
- Structure:
  - `Program.cs`: Entry point for SRP examples
  - `Enums/`: Contains supporting enums (e.g., `LeaveType.cs`)
  - `Interfaces/`: Interface definitions for SRP (e.g., `ILeaveManager.cs`, `ISalaryCalculator.cs`)
  - `Models/`: Data models used in SRP examples
  - `Services/`: Service classes implementing business logic

**Start here: [Single Responsibility Principle](../docs/srp.md)**

## Implementation Pattern

Each design principle follows a consistent pattern:
1. Entry point (`Program.cs`) to run the examples
2. Interfaces define contracts for services
3. Models represent data structures
4. Services implement business logic, adhering to the principle being demonstrated

## Progressive Learning

The project is designed for progressive learning:
1. Start with [Single Responsibility Principle](../docs/srp.md)
2. Continue with other SOLID principles as they are added (OCP, LSP, ISP, DIP)
3. Refer to OOP_Basics for foundational concepts

Each principle builds upon OOP fundamentals, with practical examples and real-world scenarios.

## Running Examples

To run examples:
1. Open the relevant `Program.cs` (e.g., in `SRP/`)
2. Uncomment or modify the example you want to run
3. Run the application using:
   ```bash
   dotnet run
   ```
   (from the appropriate project directory)

## Best Practices

1. Each principle is self-contained in its own folder
2. Code is well-commented for learning
3. Examples progress from simple to more realistic
4. Clear separation between interfaces, models, and services
5. Documentation provided for each principle

## Next Steps

Ready to start learning? Begin with [Single Responsibility Principle](../docs/srp.md) and follow the learning path as new principles are added. Each section contains detailed explanations, examples, and best practices to help you master software design principles in C#.
