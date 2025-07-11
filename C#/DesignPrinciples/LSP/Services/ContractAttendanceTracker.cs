using LSP.Models;

namespace LSP.Services
{
    class ContractAttendanceTracker : BaseAttendanceTracker
    {
        public override bool Supports(Employee employee) => employee is ContractEmployee;
    }
}
