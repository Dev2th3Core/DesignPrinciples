using ISP.Interfaces;
using ISP.Models;

namespace ISP.Services
{
    class InternSalaryCalculator : ISalaryCalculator
    {
        public bool Supports(Employee employee) => employee is InternEmployee;

        public double Calculate(SalaryDetails salary)
        {
            return (salary.BaseSalary ?? 0) + (salary.Bonus ?? 0);
        }
    }
}
