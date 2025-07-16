# Interface Segregation Principle (ISP)

## What is ISP?

Continuing our SOLID journey, let's explore the fourth principle:
**What is the Interface Segregation Principle?**

ISP states:
> "Clients should not be forced to depend on interfaces they do not use."

In other words, it's better to have several small, specific interfaces rather than a large, general-purpose one. This ensures that implementing classes only need to be concerned with the methods that are relevant to them, leading to a more modular, flexible, and maintainable codebase.

## Why do we need ISP?

Imagine a system where you have different types of employees (Permanent, Contract, Intern) and features like Leave, Salary, and Attendance. If all employee types are forced to implement methods or logic that don't apply to them, the code becomes fragile, hard to extend, and violates the spirit of SOLID. ISP helps you design systems where each type only implements what it truly needs.

## How was ISP achieved in our project?

### The Challenge

Initially, the `ApproveAttendance` and `ApproveLeave` methods were implemented directly in the `BaseAttendanceManager` and `BaseLeaveManager` classes. Both Permanent and Contract manager classes inherited from these base classes, which meant that the approval methods were accessible to both Permanent and Contract manager classes. This was problematic because contract employees should not have access to approval logic only permanent employees should be able to approve leave and attendance. This design flaw violated the Interface Segregation Principle (ISP), as it forced contract-related classes to depend on methods they should not use, and also risked accidental misuse of approval functionality.

Originally, the approval logic for Leave and Attendance was handled in a way that grouped Permanent and Contract employees together. This meant that both types had to deal with approval logic, even if their requirements were different. This was a violation of both ISP and other SOLID principles (like SRP and OCP). We intentionally kept it this way to demonstrate how to refactor for ISP.

### ISP Solution: Introducing Segregated Approval Interfaces

- **Abstraction:** We introduced two new interfaces: `ILeaveApprover` and `IAttendanceApprover`. These interfaces define only the approval operations for Leave and Attendance, respectively.
- **Separation of Concerns:** Now, only those classes that actually need to handle approval logic implement these interfaces. For example, `PermanentLeaveManager` implements `ILeaveApprover`, and `PermanentAttendanceManager` implements `IAttendanceApprover`.
- **Specific Implementations:**
  - `PermanentLeaveManager` handles leave approval for permanent employees.
  - `PermanentAttendanceManager` handles attendance approval for permanent employees.
  - Other managers (e.g., for Contract or Intern employees) do not need to implement these approval interfaces if they don't handle approval logic.

#### Example: Leave Approval

When you call `LeaveManager.ApproveLeave(manager, subordinate, requestId, approveLeave)`, the manager delegates the approval to the appropriate approver (e.g., `PermanentLeaveManager`). Only the relevant manager implements the approval interface, keeping the code clean and focused.

#### Example: Attendance Approval

Similarly, `AttendanceManager.ApproveAttendance(attendanceId, manager, subordinate, approveAttendance)` delegates to the correct approver. Only the necessary classes implement the approval logic.

**Result:**
- Each class only implements the interfaces it actually needs.
- No class is forced to implement irrelevant methods.
- The code is more modular, easier to extend, and adheres to ISP.

## Introducing a New Feature: Intern Employee Type

### The Challenge

We wanted to add support for a new employee type: **Intern**. In a non-ISP-compliant design, this would require modifying existing interfaces and classes, risking bugs and breaking changes.

### ISP in Action

- **New Model:** We introduced `InternEmployee` and `InternEmployeeLeaveBalance` to represent interns and their leave balances.
- **Specific Managers:**
  - `InternLeaveManager` handles leave requests for interns (e.g., only unpaid leave is allowed).
  - `InternAttendanceManager` handles attendance for interns.
  - `InternSalaryCalculator` handles salary calculation for interns.
- **No Unnecessary Implementation:** Intern managers do not implement approval interfaces if they don't need to. They only implement what is relevant to their role.
- **Plug-and-Play:** To add support for interns, we simply created new classes and registered them in the relevant managers. No changes were needed to existing code or interfaces.

**Result:**
- Adding a new employee type (Intern) was easy and safe.
- No existing code was broken or modified.
- The system remains open for extension and closed for modification (OCP), and each class only depends on the interfaces it needs (ISP).

## Why is this important?

- **Extensibility:** Adding new types or features is straightforward just implement the relevant interfaces.
- **Safety:** No risk of breaking existing logic when adding new types.
- **Maintainability:** Each class is focused and only implements what it needs, making the codebase easier to understand and maintain.

## Best Practices for ISP

- Design small, focused interfaces for each responsibility.
- Avoid "fat" interfaces that force classes to implement unused methods.
- When adding new features or types, prefer creating new interfaces or implementations rather than modifying existing ones.
- Use composition and delegation to keep classes focused and modular.

## Advanced Examples

- ISP applies not just to classes, but to services and modules. For example, the leave, attendance, and salary managers all use lists of strategies (implementations) and delegate to the correct one at runtime.
- Combine ISP with OCP: Add new types by creating new classes and interfaces, not by modifying existing logic.
- Use dependency injection to provide the correct implementation at runtime.

## Next Steps

By applying the Interface Segregation Principle, your codebase becomes more modular, extensible, and easier to maintain. Review your own projects for places where classes are forced to implement irrelevant methods, or where interfaces are too broad. Refactor these areas to use smaller, more focused interfaces and ensure that each class only depends on what it actually needs.

Ready for the next SOLID principle? Check out the [DIP documentation](./dip.md) to learn about the Dependency Inversion Principle, or revisit the [LSP documentation](./lsp.md) for more SOLID principles in action.
