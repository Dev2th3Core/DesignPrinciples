# Single Responsibility Principle (SRP)

## What is SRP?

Let’s start with a simple question:  
**What is the Single Responsibility Principle?**

SRP is the first principle of SOLID, and it says:  
> “A class should have only one reason to change.”

In other words, every class should focus on doing just one thing, and do it well. If a class is responsible for more than one job, it becomes harder to maintain, test, and extend.

## Why do we need SRP?

Imagine you have a class that manages employee data, calculates salaries, and handles leave requests all in one place.  
What happens if the rules for salary calculation change? Or if the leave policy is updated?  
You’d have to change the same class for every new requirement, risking bugs and making your code harder to understand.

SRP helps us avoid this by encouraging us to split responsibilities into separate classes. This way, each class has a clear purpose, and changes in one area don’t accidentally break something else.

## How was SRP violated in the OOP_Basics project?

Let’s look at our previous OOP_Basics project.  
There, the `Employee` class was a “jack of all trades.” It handled:

- Employee details (like name and ID)
- Salary calculation
- Leave management

Here’s what that means:  
If you wanted to change how salaries are calculated, you’d have to touch the `Employee` class.  
If you wanted to update leave policies, you’d have to touch the same class again.  
This is a classic SRP violation—one class, too many reasons to change!

## How do we fix this? (SRP in action)

In this project, we’ve refactored the code to follow SRP.  
Now, each responsibility has its own class:

- The `Employee` class only manages employee data.
- The `SalaryCalculator` class handles salary calculations.
- The `LeaveManager` class takes care of leave requests and balances.

Each class has a single, well-defined job.  
If you need to change how salaries are calculated, you only update the `SalaryCalculator`.  
If the leave policy changes, you only update the `LeaveManager`.  
This makes the code easier to maintain, test, and extend.

## Best Practices

- Keep your classes focused—one responsibility per class.
- If you find yourself changing a class for more than one reason, consider splitting it.
- Use clear naming to reflect each class’s responsibility.
- Favor composition over inheritance for separating concerns.
- Write unit tests for each responsibility in isolation.

## Advanced Examples

- In larger systems, SRP can be applied at the module or service level, not just classes.
- For example, in a payroll system, you might have separate services for payroll processing, tax calculation, and reporting.
- SRP also applies to methods: keep each method focused on a single task.
- Use interfaces to define contracts for each responsibility, making your code more flexible and testable.

## Next Steps

Now that you’ve seen how the Single Responsibility Principle leads to cleaner, more maintainable code, you’re ready to explore the next SOLID principle: the [Open/Closed Principle](./ocp.md) (OCP). OCP will show you how to design your classes so they can be extended with new features without modifying existing, working code.

Remember: SRP is all about focus. Give each class one job, and your codebase will thank you! Try reviewing your own projects for classes that do too much, and practice splitting them up. The more you apply SRP, the easier it will be to build robust, flexible applications.

For a refresher on OOP basics, check out the [OOP_Basics](../DesignPrinciples/OOP_Basics/) folder or the [OOP](https://github.com/Rakshit4045/oops) repository documentation.
