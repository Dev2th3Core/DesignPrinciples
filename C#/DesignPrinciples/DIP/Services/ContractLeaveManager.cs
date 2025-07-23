using DIP.Enums;
using DIP.Models;
using DIP.Repository;

namespace DIP.Services
{
    class ContractLeaveManager : BaseLeaveManager
    {
        public ContractLeaveManager(ILeaveRepository leaveRepository) : base(leaveRepository)
        {
        }

        public override bool Supports(Employee employee) => employee is ContractEmployee;

        public override bool SupportsLeaveType(Employee employee, LeaveType leaveType)
        {
            // Contract employees can only take unpaid leave
            return leaveType == LeaveType.Unpaid;
        }
    }
}
