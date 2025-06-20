using SRP.Interfaces;
using SRP.Models;

namespace SRP.Services
{
    public class SalaryCalculator : ISalaryCalculator
    {
        private readonly List<SalaryDetails> _salaries;

        public SalaryCalculator(List<SalaryDetails> salaries)
        {
            _salaries = salaries;
        }

        public double CalculateSalary(Employee employee)
        {
            var salary = _salaries.FirstOrDefault(s => s.EmployeeId == employee.Id);
            return salary?.CalculatePay() ?? 0;
        }
    }
}
