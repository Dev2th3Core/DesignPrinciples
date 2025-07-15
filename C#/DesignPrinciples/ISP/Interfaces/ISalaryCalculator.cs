using ISP.Models;

namespace ISP.Interfaces
{
    public interface ISalaryCalculator
    {
        bool Supports(Employee employee);
        double Calculate(SalaryDetails salary);
    }
}
