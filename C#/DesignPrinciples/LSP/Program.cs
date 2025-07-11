using LSP.Enums;
using LSP.Interfaces;
using LSP.Models;
using LSP.Services;

namespace LSP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========= LSP DEMO START =========\n");

            // Manager
            var manager = new PermanentEmployee("Olivia", new PermanentEmployeeLeaveBalance());
            manager.DisplayDetails();

            // Permanent Employees
            var emp1 = new PermanentEmployee("Liam", new PermanentEmployeeLeaveBalance()) { ManagerId = manager.Id };
            emp1.DisplayDetails();
            var emp2 = new PermanentEmployee("Ava", new PermanentEmployeeLeaveBalance()) { ManagerId = manager.Id };
            emp2.DisplayDetails();

            // Contract Employee (no leave for now)
            var contractEmp = new ContractEmployee("Noah", new ContractEmployeeLeaveBalance()) { ManagerId = manager.Id };
            contractEmp.DisplayDetails();


            // Salary Data
            var salaries = new Dictionary<Guid, SalaryDetails>
            {
                [manager.Id] = new SalaryDetails(manager.Id) { BaseSalary = 100_000, Bonus = 20_000 },
                [emp1.Id] = new SalaryDetails(emp1.Id) { BaseSalary = 80_000, Bonus = 10_000 },
                [emp2.Id] = new SalaryDetails(emp2.Id) { BaseSalary = 70_000, Bonus = 9_000 },
                [contractEmp.Id] = new SalaryDetails(contractEmp.Id) { HourlyRate = 700, HoursWorked = 80 }
            };

            // Register strategies
            var salaryStrategyList = new List<ISalaryCalculator>
            {
                new PermanentSalaryCalculator(),
                new ContractSalaryCalculator()
            };

            var calculator = new SalaryCalculationManager(salaryStrategyList);

            // Print salaries
            Console.WriteLine("-- Salaries --");
            Console.WriteLine($"{manager.Name}: ${calculator.CalculateSalary(manager, salaries[manager.Id])}");
            Console.WriteLine($"{emp1.Name}: ${calculator.CalculateSalary(emp1, salaries[emp1.Id])}");
            Console.WriteLine($"{emp2.Name}: ${calculator.CalculateSalary(emp2, salaries[emp2.Id])}");
            Console.WriteLine($"{contractEmp.Name}: ${calculator.CalculateSalary(contractEmp, salaries[contractEmp.Id])}");

            var leaveStrategyList = new List<ILeaveManager>
            {
                new PermanentLeaveManager(),
                new ContractLeaveManager()
            };

            // Leave Manager
            var leaveManager = new LeaveManager(leaveStrategyList);

            // Leave Request: emp1 - Paid, emp2 - Casual, contractEmp - Unpaid
            var leave1 = leaveManager.SubmitLeave(emp1, LeaveType.Paid, 2);
            var leave2 = leaveManager.SubmitLeave(emp2, LeaveType.Casual, 1);
            var leave3 = leaveManager.SubmitLeave(contractEmp, LeaveType.Paid, 3); // Contract employee requesting Paid leave (should fail)
            var leave4 = leaveManager.SubmitLeave(contractEmp, LeaveType.Unpaid, 5); // Contract employee requesting Unpaid leave
            Console.WriteLine();


            // Manager Approves Leaves
            leaveManager.ApproveLeave(manager, emp1, leave1.RequestId, true);
            Console.WriteLine($"{emp1.Name} Leave Type: {leave1.LeaveType} Leave Status: {leave1.Status}");
            leaveManager.ApproveLeave(manager, emp2, leave2.RequestId, true);
            Console.WriteLine($"{emp2.Name} Leave Type: {leave2.LeaveType} Leave Status: {leave2.Status}");
            leaveManager.ApproveLeave(manager, contractEmp, leave4.RequestId, true);
            Console.WriteLine($"{contractEmp.Name} Leave Type: {leave4.LeaveType} Leave Status: {leave4.Status}");
            Console.WriteLine();

            
            // Leave Balance Check
            Console.WriteLine("-- Leave Balance After Approval --");
            Console.WriteLine($"{emp1.Name} Paid Leave Left: {emp1.LeaveBalance.GetLeaveBalance(LeaveType.Paid)}");
            Console.WriteLine($"{emp2.Name} Casual Leave Left: {emp2.LeaveBalance.GetLeaveBalance(LeaveType.Casual)}");
            Console.WriteLine($"{contractEmp.Name} Unpaid Leave Left: {contractEmp.LeaveBalance.GetLeaveBalance(LeaveType.Unpaid)}");

            var attendanceStrategyList = new List<IAttendanceTracker>
            {
                new PermanentAttendanceTracker(),
                new ContractAttendanceTracker()
            };

            var attendanceTracker = new AttendanceManager(attendanceStrategyList);

            // Mark Attendance
            Console.WriteLine("\n-- Marking Attendance --");
            var attendance1 = attendanceTracker.MarkAttendance(emp1, new Attendance(emp1.Id, DateTime.Now, 8, AttendanceType.FullDay));
            var attendance2 = attendanceTracker.MarkAttendance(emp2, new Attendance(emp2.Id, DateTime.Now, 4, AttendanceType.HalfDay));
            var attendance3 = attendanceTracker.MarkAttendance(contractEmp, new Attendance(contractEmp.Id, DateTime.Now, 8, AttendanceType.FullDay));

            // Manager Approves Attendance
            Console.WriteLine("\n-- Approving Attendance --");
            attendanceTracker.ApproveAttendance(attendance1.Id, manager, emp1, true);
            attendanceTracker.ApproveAttendance(attendance2.Id, manager, emp2, true);
            attendanceTracker.ApproveAttendance(attendance3.Id, manager, contractEmp, false); // Contract employee's attendance rejected

            Console.WriteLine("\n========= LSP DEMO END =========");
        }
    }
}
