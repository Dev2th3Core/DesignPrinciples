using OCP.Enums;
using OCP.Models;

namespace OCP.Services
{
    class PermanentLeaveManager : BaseLeaveManager
    {
        public override bool Supports(Employee employee) => employee is PermanentEmployee;

        public override bool SupportsLeaveType(Employee employee, LeaveType leaveType)
        {
            return true; // Permanent employees can take all types of leave
        }
    }
}
