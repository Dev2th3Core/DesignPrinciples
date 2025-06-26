using OCP.Models;

namespace OCP.Interfaces
{
    public interface ISalaryCalculator
    {
        bool Supports(Employee employee);
        double Calculate(SalaryDetails salary);
    }
}
