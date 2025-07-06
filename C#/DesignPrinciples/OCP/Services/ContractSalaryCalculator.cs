using OCP.Interfaces;
using OCP.Models;

namespace OCP.Services
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
