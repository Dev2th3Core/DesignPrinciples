using OCP.Enums;
using OCP.Interfaces;
using OCP.Models;
using OCP.Services;

namespace OCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========= OCP DEMO START =========\n");

            // Manager
            var manager = new PermanentEmployee("Olivia");
            manager.DisplayDetails();

            // Permanent Employees
            var emp1 = new PermanentEmployee("Liam") { ManagerId = manager.Id };
            emp1.DisplayDetails();
            var emp2 = new PermanentEmployee("Ava") { ManagerId = manager.Id };
            emp2.DisplayDetails();

            // Contract Employee (no leave for now)
            var contractEmp = new ContractEmployee("Noah");
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
            var strategyList = new List<ISalaryCalculator>
            {
                new PermanentSalaryCalculator(),
                new ContractSalaryCalculator()
            };

            var calculator = new SalaryCalculationManager(strategyList);

            // Print salaries
            Console.WriteLine("-- Salaries --");
            Console.WriteLine($"{manager.Name}: ${calculator.CalculateSalary(manager, salaries[manager.Id])}");
            Console.WriteLine($"{emp1.Name}: ${calculator.CalculateSalary(emp1, salaries[emp1.Id])}");
            Console.WriteLine($"{emp2.Name}: ${calculator.CalculateSalary(emp2, salaries[emp2.Id])}");
            Console.WriteLine($"{contractEmp.Name}: ${calculator.CalculateSalary(contractEmp, salaries[contractEmp.Id])}");
            
            // Leave Manager
            var leaveManager = new LeaveManager();

            // Leave Request: emp1 - Paid, emp2 - Casual
            var leave1 = leaveManager.SubmitLeave(emp1, LeaveType.Paid, 2);
            var leave2 = leaveManager.SubmitLeave(emp2, LeaveType.Casual, 1);
            Console.WriteLine();

            // Manager Approves Leaves
            leaveManager.ApproveLeave(manager, emp1, leave1.RequestId, true);
            Console.WriteLine($"{emp1.Name} Leave Status: {leave1.Status}");
            leaveManager.ApproveLeave(manager, emp2, leave2.RequestId, false);
            Console.WriteLine($"{emp2.Name} Leave Status: {leave2.Status}");
            Console.WriteLine();

            // Leave Balance Check
            Console.WriteLine("-- Leave Balance After Approval --");
            Console.WriteLine($"{emp1.Name} Paid Leave Left: {emp1.LeaveBalance.PaidLeaveRemaining}");
            Console.WriteLine($"{emp2.Name} Casual Leave Left: {emp2.LeaveBalance.CasualLeaveRemaining}");

            Console.WriteLine("\n========= OCP DEMO END =========");
        }
    }
}
