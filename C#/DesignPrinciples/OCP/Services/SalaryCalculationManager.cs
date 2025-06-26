using OCP.Interfaces;
using OCP.Models;

namespace OCP.Services
{
    public class SalaryCalculationManager
    {
        private readonly List<ISalaryCalculator> _strategies;

        public SalaryCalculationManager(List<ISalaryCalculator> strategies)
        {
            _strategies = strategies;
        }

        public double CalculateSalary(Employee employee, SalaryDetails salary)
        {
            var strategy = _strategies.FirstOrDefault(s => s.Supports(employee));
            if (strategy == null)
                throw new InvalidOperationException("No salary strategy found for this employee type.");

            return strategy.Calculate(salary);
        }
    }
}
