# Liskov Substitution Principle (LSP)

## What is LSP?

Continuing our SOLID journey, let's explore the third principle:
**What is the Liskov Substitution Principle?**

LSP states:
> "Objects of a superclass should be replaceable with objects of a subclass without breaking the application."

In other words, if you have a base class or interface, you should be able to use any of its derived classes or implementations without the program failing or producing incorrect results. This ensures that abstractions are truly substitutable and that your code remains robust and extensible.

## Why do we need LSP?

Imagine a system where you have different types of employees (Permanent, Contract) and features like Leave, Salary, and Attendance. If you cannot safely substitute a `PermanentEmployee` with a `ContractEmployee` (or vice versa) in your business logic, your code will be fragile and hard to extend. LSP helps you design systems where new types can be introduced without breaking existing functionality.

## How was LSP already handled in our previous code?

In our earlier implementations for Employee, Leave, and Salary features, we already followed LSP:

- **Employee:** Both `PermanentEmployee` and `ContractEmployee` inherit from the abstract `Employee` class. Anywhere an `Employee` is expected, either type can be used without breaking the logic.
- **Leave:** The leave management system uses the `ILeaveManager` interface and concrete managers for each employee type. The system can handle any `ILeaveManager` implementation, ensuring substitutability.
- **Salary:** Salary calculation is handled via the `ISalaryCalculator` interface, with specific calculators for each employee type. The salary calculation manager can use any implementation, maintaining LSP.

## The New Attendance Feature: LSP in Action

### The Challenge

With the introduction of the Attendance feature, we needed to ensure that marking and approving attendance for different employee types would not break the system, and that new types could be added seamlessly.

### LSP Solution

- **Abstraction:** We introduced the `IAttendanceTracker` interface, which defines the contract for attendance operations (marking, approving, retrieving attendance records).
- **Base Class:** The `BaseAttendanceTracker` abstract class provides shared logic for common attendance operations, reducing code duplication.
- **Concrete Implementations:**
  - `PermanentAttendanceTracker` handles attendance for permanent employees.
  - `ContractAttendanceTracker` handles attendance for contract employees.
- **Manager Class:** The `AttendanceManager` class accepts a list of `IAttendanceTracker` strategies. When an attendance operation is requested, it delegates to the appropriate tracker based on the employee type.

#### Example: Marking Attendance

When you call `AttendanceManager.MarkAttendance(employee, attendance)`, the manager:
1. Finds the correct `IAttendanceTracker` implementation for the employee type.
2. Calls `MarkAttendance` on that tracker.
3. The logic works regardless of whether the employee is permanent or contract, and new types can be added by simply implementing a new tracker.

**Result:**
- You can substitute any `IAttendanceTracker` implementation without breaking the system.
- The attendance logic is open for extension (add new employee types) but closed for modification (no need to change existing code).
- This is a textbook application of LSP.

### Why is this important?

- **Extensibility:** If you add a new employee type (e.g., Intern), you just create a new tracker implementing `IAttendanceTracker`. The rest of the system works as before.
- **Safety:** The system never needs to know the concrete type of employee; it relies on the abstraction.
- **Maintainability:** No fragile type checks or casts are needed. The code is robust and easy to maintain.

## Best Practices for LSP

- Always program to abstractions (interfaces or abstract classes).
- Ensure that derived classes or implementations honor the contract of the base class/interface.
- Avoid type checks (`if`/`switch` on types) in business logic; use polymorphism instead.
- When adding new features, ensure they can be used interchangeably via their abstraction.

## Advanced Examples

- LSP applies not just to classes, but to services and modules. For example, the attendance, leave, and salary managers all use lists of strategies (implementations) and delegate to the correct one at runtime.
- Combine LSP with OCP: Add new types by creating new classes, not by modifying existing logic.
- Use dependency injection to provide the correct implementation at runtime.

## Next Steps

By applying the Liskov Substitution Principle, your codebase becomes safer, more extensible, and easier to maintain. Try reviewing your own projects for places where you rely on concrete types, type checks, or where substituting one implementation for another could break your logic. Refactor these areas to use abstractions and ensure true substitutability.

Ready for the next SOLID principle? Check out the [ISP documentation](./ISP.md) to learn how to design even more robust interfaces, or revisit the [OCP documentation](./ocp.md) for more SOLID principles in action.
