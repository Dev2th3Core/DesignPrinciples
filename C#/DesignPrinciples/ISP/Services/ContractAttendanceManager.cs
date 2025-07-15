using ISP.Models;

namespace ISP.Services
{
    class ContractAttendanceManager : BaseAttendanceManager
    {
        public override bool Supports(Employee employee) => employee is ContractEmployee;
    }
}
