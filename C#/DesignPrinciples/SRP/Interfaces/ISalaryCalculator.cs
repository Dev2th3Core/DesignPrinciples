using SRP.Models;

namespace SRP.Interfaces
{
    interface ISalaryCalculator
    {
        double CalculateSalary(Employee employee);
    }
}
