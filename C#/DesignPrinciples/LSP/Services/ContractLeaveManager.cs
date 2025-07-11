using LSP.Enums;
using LSP.Models;

namespace LSP.Services
{
    class ContractLeaveManager : BaseLeaveManager
    {
        public override bool Supports(Employee employee) => employee is ContractEmployee;

        public override bool SupportsLeaveType(Employee employee, LeaveType leaveType)
        {
            // Contract employees can only take unpaid leave
            return leaveType == LeaveType.Unpaid;
        }
    }
}
