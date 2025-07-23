# Dependency Inversion Principle (DIP)

## What is DIP?

Continuing our SOLID journey, let's explore the fifth principle:
**What is the Dependency Inversion Principle?**

DIP states:
> "High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions."

In other words, your business logic (high-level modules) should not be tightly coupled to the details of data storage or other low-level operations. Instead, both should depend on interfaces (abstractions), making your code more flexible, testable, and maintainable.

## Why do we need DIP?

Imagine a system where service classes (like attendance and leave managers) directly manage in-memory lists for storing data. This tightly couples your business logic to a specific data storage mechanism, making it hard to change, extend, or test. DIP helps you design systems where high-level logic is decoupled from low-level details, allowing you to swap out implementations (e.g., switch from in-memory to database storage) with minimal changes.

## How was DIP achieved in our project?

### The Challenge

Initially, the `BaseAttendanceManager` and `BaseLeaveManager` classes directly managed lists for storing attendance and leave requests:

```csharp
// In BaseAttendanceManager
protected List<Attendance> _attendanceList = new List<Attendance>();

// In BaseLeaveManager
protected List<LeaveRequest> _leaveRequests = new List<LeaveRequest>();
```

This design meant that all derived classes (like `PermanentAttendanceManager` and `PermanentLeaveManager`) accessed and manipulated the base class's data storage details through inheritance. While inheritance itself does not violate the Dependency Inversion Principle (DIP), this approach tightly couples the derived classes to the concrete implementation of data storage in the base class. According to DIP, 'Abstractions should not depend on details. Details should depend on abstractions.' If, in the future, any other class (not inheriting from the base manager) needed to access or share the same data list, it would have to depend directly on the concrete list implementation, clearly violating DIP. Our refactored implementation removes this risk by introducing repository abstractions, ensuring that all classes now and in the future depend on abstractions rather than concrete details, thus fully adhering to DIP.

#### Example: Attendance (Before DIP)

```csharp
// In BaseAttendanceManager
protected List<Attendance> _attendanceList = new List<Attendance>();

public virtual Attendance MarkAttendance(Employee employee, Attendance attendance)
{
    _attendanceList.Add(attendance);
    // ...
}
```

#### Example: Leave (Before DIP)

```csharp
// In BaseLeaveManager
protected List<LeaveRequest> _leaveRequests = new List<LeaveRequest>();

public virtual LeaveRequest SubmitLeave(Employee employee, LeaveType type, int days)
{
    var request = new LeaveRequest(employee.Id, type, days);
    _leaveRequests.Add(request);
    // ...
}
```

### DIP Solution: Introducing Repository Interfaces

- **Abstraction:** We introduced repository interfaces: `IAttendanceRepository` and `ILeaveRepository`. These interfaces define the operations for storing and retrieving attendance and leave data, without specifying how the data is stored.
- **Separation of Concerns:** Concrete repository implementations (e.g., `InMemoryAttendanceRepository`, `InMemoryLeaveRepository`) handle the actual data storage, whether in-memory, database, or otherwise.
- **Dependency Injection:** Service classes (like attendance and leave managers) now depend on these repository interfaces, which are injected via their constructors. This decouples the business logic from the data storage details.

#### Example: Attendance (After DIP)

```csharp
// IAttendanceRepository abstraction
public interface IAttendanceRepository
{
    void Add(Attendance attendance);
    Attendance? GetById(Guid attendanceId);
    // ... other methods
}

// InMemoryAttendanceRepository implementation
class InMemoryAttendanceRepository : IAttendanceRepository
{
    private readonly List<Attendance> _attendances = new();
    public void Add(Attendance attendance) => _attendances.Add(attendance);
    // ...
}

// BaseAttendanceManager now depends on abstraction
public abstract class BaseAttendanceManager : IAttendanceManager
{
    private readonly IAttendanceRepository _attendanceRepository;
    public BaseAttendanceManager(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }
    public Attendance MarkAttendance(Employee employee, Attendance attendance)
    {
        _attendanceRepository.Add(attendance);
        // ...
    }
}
```

#### Example: Leave (After DIP)

```csharp
// ILeaveRepository abstraction
public interface ILeaveRepository
{
    void AddLeaveRequest(LeaveRequest leaveRequest);
    LeaveRequest? GetLeaveRequestById(Guid leaveRequestId);
    // ... other methods
}

// InMemoryLeaveRepository implementation
class InMemoryLeaveRepository : ILeaveRepository
{
    private readonly List<LeaveRequest> _leaveRequests = new();
    public void AddLeaveRequest(LeaveRequest leaveRequest) => _leaveRequests.Add(leaveRequest);
    // ...
}

// BaseLeaveManager now depends on abstraction
public abstract class BaseLeaveManager : ILeaveManager
{
    private readonly ILeaveRepository _leaveRepository;
    public BaseLeaveManager(ILeaveRepository leaveRepository)
    {
        _leaveRepository = leaveRepository;
    }
    public LeaveRequest SubmitLeave(Employee employee, LeaveType type, int days)
    {
        var request = new LeaveRequest(employee.Id, type, days);
        _leaveRepository.AddLeaveRequest(request);
        // ...
    }
}
```

### How does this help?

- **Decoupling:** High-level modules (service classes) no longer depend on low-level data storage details. They depend on abstractions (repository interfaces).
- **Flexibility:** You can easily swap out the data storage implementation (e.g., switch from in-memory to database) without changing the business logic.
- **Testability:** You can mock repository interfaces for unit testing, making tests more reliable and focused.
- **Extensibility:** Adding new storage mechanisms or changing existing ones is straightforward and does not affect the service layer.

## Why is this important?

- **Maintainability:** The codebase is easier to maintain and extend, as changes in data storage do not ripple through the business logic.
- **Scalability:** The system can grow and adapt to new requirements (e.g., new storage backends) with minimal changes.
- **SOLID Compliance:** The project now adheres to the Dependency Inversion Principle, making it more robust and future-proof.

## Best Practices for DIP

- Always depend on abstractions, not concretions.
- Use interfaces to define contracts for data access and other low-level operations.
- Inject dependencies via constructors to make classes easier to test and extend.
- Keep high-level business logic decoupled from low-level implementation details.

## Next Steps

By applying the Dependency Inversion Principle, your codebase becomes more modular, testable, and adaptable to change. Review your own projects for places where high-level logic is tightly coupled to low-level details, and refactor to use abstractions and dependency injection wherever possible.

Thank you for following along with the SOLID principles journey so far! If you'd like to revisit any of the SOLID principles from the beginning, you can start from the [SOLID Introduction](./srp.md) and navigate through each principle. 

As a continuation of this project, I am currently working on a new project focused on [Design Patterns](https://github.com/Dev2th3Core/DesignPatterns), which will build upon the concepts covered here. The Design Patterns project is a work in progress (WIP), so stay tuned for updates!
