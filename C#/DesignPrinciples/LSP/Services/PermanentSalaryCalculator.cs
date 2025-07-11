using LSP.Interfaces;
using LSP.Models;

namespace LSP.Services
{
    class PermanentSalaryCalculator : ISalaryCalculator
    {
        public bool Supports(Employee employee) => employee is PermanentEmployee;

        public double Calculate(SalaryDetails salary)
        {
            return (salary.BaseSalary ?? 0) + (salary.Bonus ?? 0);
        }
    }
}
