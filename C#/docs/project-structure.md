# Project Structure

This document explains the organization of the DesignPrinciples project and how the SOLID software design principles are implemented in C#.

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
│   ├── Interfaces/                           # Interface definitions
│   ├── Models/                               # Data models
│   └── Services/                             # Service implementations
├── OCP/                                      # Open/Closed Principle
│   └── ... (same structure as SRP)
├── LSP/                                      # Liskov Substitution Principle
│   └── ... (same structure as SRP)
├── ISP/                                      # Interface Segregation Principle
│   └── ... (same structure as SRP)
├── DIP/                                      # Dependency Inversion Principle
│   └── ... (same structure as SRP)
└── docs/                                     # Documentation for all the Principles
    └── ...
```

> **Note:** Each SOLID principle project (OCP, LSP, ISP, DIP) follows the same internal folder structure as SRP, containing subfolder for Enums, Interfaces, Models, and Services as appropriate. While the DIP project additionally contains Repository folder.

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
- **Revisit** - [OOP Basics](../docs/oop.md)

### Single Responsibility Principle (SRP)
- Location: `SRP/`
- Purpose: Demonstrates the Single Responsibility Principle
- Structure: Interfaces, models, enums, and services for SRP
- **Start here: [Single Responsibility Principle](../docs/srp.md)**

### Open/Closed Principle (OCP)
- Location: `OCP/`
- Purpose: Demonstrates the Open/Closed Principle
- Structure: Interfaces, models, enums, and services for OCP
- **Learn more: [Open/Closed Principle](../docs/ocp.md)**

### Liskov Substitution Principle (LSP)
- Location: `LSP/`
- Purpose: Demonstrates the Liskov Substitution Principle
- Structure: Interfaces, models, enums, and services for LSP
- **Learn more: [Liskov Substitution Principle](../docs/lsp.md)**

### Interface Segregation Principle (ISP)
- Location: `ISP/`
- Purpose: Demonstrates the Interface Segregation Principle
- Structure: Interfaces, models, enums, and services for ISP
- **Learn more: [Interface Segregation Principle](../docs/isp.md)**

### Dependency Inversion Principle (DIP)
- Location: `DIP/`
- Purpose: Demonstrates the Dependency Inversion Principle
- Structure: Interfaces, models, enums, repositories, and services for DIP
- **Learn more: [Dependency Inversion Principle](../docs/dip.md)**

## Implementation Pattern

Each design principle follows a consistent pattern:
1. Entry point (`Program.cs`) to run the examples
2. Interfaces define contracts for services
3. Models represent data structures
4. Services implement business logic, adhering to the principle being demonstrated
5. Supporting enums and repositories as needed

## Progressive Learning

The project is designed for progressive learning:
1. Start with [Single Responsibility Principle](../docs/srp.md)
2. Continue with [Open/Closed Principle](../docs/ocp.md)
3. Move to [Liskov Substitution Principle](../docs/lsp.md)
4. Explore [Interface Segregation Principle](../docs/isp.md)
5. Finish with [Dependency Inversion Principle](../docs/dip.md)
6. Refer to [OOP_Basics](../docs/oop.md) for foundational concepts

Each principle builds upon OOP fundamentals, with practical examples and real-world scenarios.

## Running Examples

To run examples:
1. Open the relevant `Program.cs` (e.g., in `SRP/`, `OCP/`, etc.)
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

Ready to start learning? Begin with [Single Responsibility Principle](../docs/srp.md) and follow the learning path through all SOLID principles. Each section contains detailed explanations, examples, and best practices to help you master SOLID software design principles in C#.
