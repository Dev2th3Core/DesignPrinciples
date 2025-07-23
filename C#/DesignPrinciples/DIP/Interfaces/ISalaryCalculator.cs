using DIP.Models;

namespace DIP.Interfaces
{
    public interface ISalaryCalculator
    {
        bool Supports(Employee employee);
        double Calculate(SalaryDetails salary);
    }
}
