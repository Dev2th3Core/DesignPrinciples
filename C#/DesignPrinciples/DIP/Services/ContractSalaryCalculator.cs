using DIP.Interfaces;
using DIP.Models;

namespace DIP.Services
{
    class ContractSalaryCalculator : ISalaryCalculator
    {
        public bool Supports(Employee employee) => employee is ContractEmployee;

        public double Calculate(SalaryDetails salary)
        {
            return (salary.HourlyRate ?? 0) * (salary.HoursWorked ?? 0);
        }
    }
}
