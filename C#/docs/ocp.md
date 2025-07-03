# Open/Closed Principle (OCP)

## What is OCP?

Let's continue our SOLID journey with the second principle:
**What is the Open/Closed Principle?**

OCP states:
> "Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification."

In other words, you should be able to add new features or behaviors to your code without changing existing, working code. This helps prevent bugs and makes your codebase more robust and adaptable to change.

## Why do we need OCP?

Imagine you have a payroll system that calculates salaries and manages leave for different types of employees. If every time you add a new employee type or a new leave policy you have to modify existing classes, you risk breaking working code and making maintenance harder.

OCP encourages you to design your system so that new requirements can be met by adding new code, not by changing old code. This leads to more stable, flexible, and maintainable software.

## How was OCP missing in the SRP project?

In the SRP project, we split responsibilities into separate classes (like `Employee`, `SalaryCalculator`, and `LeaveManager`). However, when a new employee type (e.g., Contract vs. Permanent) or a new leave/salary policy was needed, we had to modify the core logic in these classes. This violated OCP, because the classes were not closed for modification.

For example:
- Adding a new leave calculation rule meant editing the `LeaveManager`.
- Supporting a new employee type required changes in multiple places.

## How did we achieve OCP in this project? (OCP in action)

We refactored the code to follow the Open/Closed Principle by introducing clear extension points and separating concerns. Here's how OCP was implemented for each major responsibility:

### OCP in Salary Calculation

- **Old Approach:**
  - The salary calculation logic was centralized is `SalaryCalculator` (you can check it [here](../DesignPrinciples/SRP/Services/SalaryCalculator.cs)). Adding a new employee type or salary policy required modifying the existing salary calculation code, risking bugs and making the code harder to maintain.
- **OCP Solution:**
  - Introduced the `ISalaryCalculator` interface to define a contract for salary calculation.
  - Created separate classes for each employee type, such as `PermanentSalaryCalculator` and `ContractSalaryCalculator`, each implementing `ISalaryCalculator`.
  - The `SalaryCalculationManager` delegates the calculation to the appropriate implementation based on employee type.
  - **Result:** To add a new salary policy or employee type, simply implement a new class—no changes to existing, tested code.

### OCP in Leave Management

- **Old Approach:**
  - Leave management logic was handled in a single class which was `LeaveManager` (you can check [here](../DesignPrinciples/SRP/Services/LeaveManager.cs)). Adding new leave rules or employee types meant editing this class, leading to code bloat and increased risk of errors.
- **OCP Solution:**
  - Introduced the `ILeaveManager` interface to define a contract for leave management.
  - Created an abstract `BaseLeaveManager` class to hold shared logic and avoid code duplication.
  - Specific leave managers like `PermanentLeaveManager` and `ContractLeaveManager` extend `BaseLeaveManager` and implement their own rules.
  - The main leave management system delegates to the correct manager based on employee type.
  - **Result:** New leave policies or employee types can be added by creating new classes, without modifying existing logic.

### Why Use an Abstract BaseLeaveManager?

- **Avoid Code Duplication:**
  - Common logic (such as SubmitLeave, CancelLeave and ApproveLeave methods) is placed in `BaseLeaveManager`.
  - Concrete leave managers inherit this logic, reducing repetition and making maintenance easier.
- **Facilitate Extension:**
  - New leave managers can extend the base class, inheriting shared behavior and only overriding what's unique.

### When to Apply OCP: Replace if/switch with Polymorphism

- If you see code with many `if` or `switch` statements (especially those branching on types or enums), it's often a sign that OCP can be applied.
- Instead of modifying the logic for every new case, use interfaces or abstract classes and add new subclasses for new behaviors.
- This approach makes your codebase more flexible and easier to extend.

## Best Practices

- Use interfaces and abstract classes to define extension points.
- Favor composition and delegation over large switch/case or if/else blocks.
- When requirements change, add new classes rather than modifying existing ones.
- Keep existing code closed for modification, but open for new features via new classes.

## Advanced Examples

- OCP can be applied at the service or module level, not just classes.
- Use dependency injection to provide the correct implementation at runtime.
- In large systems, use plugin architectures or strategy patterns to allow runtime extension.
- Combine OCP with SRP: each extension should have a single responsibility.

## Next Steps

By applying the Open/Closed Principle, your codebase becomes easier to extend and less prone to bugs when requirements change. Try reviewing your own projects for places where you have to modify existing code to add new features, and refactor them to use interfaces and extension points instead.

Ready for the next SOLID principle? Check out the [Liskov Substitution Principle](./lsp.md) to learn how to make your abstractions even more robust.

Remember: OCP is about building for change. Design your classes so you can add new features by writing new code, not by rewriting what already works!

For a refresher on SRP, see the [SRP documentation](./srp.md) or the [SRP project folder](../DesignPrinciples/SRP/).
