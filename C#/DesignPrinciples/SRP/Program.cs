using SRP.Enums;
using SRP.Models;
using SRP.Services;

namespace SRP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========= SRP DEMO START =========\n");

            // Manager
            var manager = new PermanentEmployee("Olivia");
            manager.DisplayDetails();

            // Permanent Employees
            var emp1 = new PermanentEmployee("Liam") { ManagerId = manager.Id };
            emp1.DisplayDetails();
            var emp2 = new PermanentEmployee("Ava") { ManagerId = manager.Id };
            emp2.DisplayDetails();

            // Contract Employee (no leave for now)
            var contractEmp = new ContractEmployee("Noah") { ManagerId = manager.Id };
            contractEmp.DisplayDetails();

            // Leave Manager
            var leaveManager = new LeaveManager();

            // Assign Salaries (Created separately)
            var salaries = new List<SalaryDetails>
            {
                new SalaryDetails(manager.Id) { BaseSalary = 100000, Bonus = 10000 },
                new SalaryDetails(emp1.Id) { BaseSalary = 75000, Bonus = 5000 },
                new SalaryDetails(emp2.Id) { BaseSalary = 72000, Bonus = 3000 },
                new SalaryDetails(contractEmp.Id) { HourlyRate = 120, HoursWorked = 160 }
            };

            // Initialize Salary Calculator
            var salaryCalculator = new SalaryCalculator(salaries);

            // Salary Display
            Console.WriteLine("-- Salary Info --");
            Console.WriteLine($"{manager.Name} Salary: {salaryCalculator.CalculateSalary(manager)}");
            Console.WriteLine($"{emp1.Name} Salary: {salaryCalculator.CalculateSalary(emp1)}");
            Console.WriteLine($"{emp2.Name} Salary: {salaryCalculator.CalculateSalary(emp2)}");
            Console.WriteLine($"{contractEmp.Name} Pay: {salaryCalculator.CalculateSalary(contractEmp)}");
            Console.WriteLine();

            // Leave Request: emp1 - Paid, emp2 - Casual
            var leave1 = leaveManager.SubmitLeave(emp1, LeaveType.Paid, 2);
            var leave2 = leaveManager.SubmitLeave(emp2, LeaveType.Casual, 1);
            var leave3 = leaveManager.SubmitLeave(contractEmp, LeaveType.Paid, 1); // Contract employee requesting paid leave (should fail)
            var leave4 = leaveManager.SubmitLeave(contractEmp, LeaveType.Unpaid, 3); // Contract employee requesting unpaid leave
            Console.WriteLine();

            // Manager Approves Leaves
            leaveManager.ApproveLeave(manager, emp1, leave1.RequestId, true);
            Console.WriteLine($"{emp1.Name} Leave Type: {leave1.LeaveType} Leave Status: {leave1.Status}");
            leaveManager.ApproveLeave(manager, emp2, leave2.RequestId, false);
            Console.WriteLine($"{emp2.Name} Leave Type: {leave2.LeaveType} Leave Status: {leave2.Status}");
            leaveManager.ApproveLeave(manager, contractEmp, leave4.RequestId, true);
            Console.WriteLine($"{contractEmp.Name} Leave Type: {leave4.LeaveType} Leave Status: {leave4.Status}");
            Console.WriteLine();

            // Leave Balance Check
            Console.WriteLine("-- Leave Balance After Approval --");
            Console.WriteLine($"{emp1.Name} Paid Leave Left: {emp1.LeaveBalance.PaidLeaveRemaining}");
            Console.WriteLine($"{emp2.Name} Casual Leave Left: {emp2.LeaveBalance.CasualLeaveRemaining}");
            Console.WriteLine($"{contractEmp.Name} Unpaid Leave Left: {contractEmp.LeaveBalance.UnPaidLeaveRemaining}");

            Console.WriteLine("\n========= SRP DEMO END =========");
        }
    }
}
