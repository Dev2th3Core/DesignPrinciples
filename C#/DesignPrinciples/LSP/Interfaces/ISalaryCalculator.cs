using LSP.Models;

namespace LSP.Interfaces
{
    public interface ISalaryCalculator
    {
        bool Supports(Employee employee);
        double Calculate(SalaryDetails salary);
    }
}
