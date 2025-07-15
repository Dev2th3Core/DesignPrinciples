using ISP.Enums;
using ISP.Models;

namespace ISP.Services
{
    class InternLeaveManager : BaseLeaveManager
    {
        public override bool Supports(Employee employee) => employee is InternEmployee;

        public override bool SupportsLeaveType(Employee employee, LeaveType leaveType)
        {
            // Interns can take only Unpaid Leave
            return leaveType == LeaveType.Unpaid;
        }
    }
}
