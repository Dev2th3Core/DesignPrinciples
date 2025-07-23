using DIP.Enums;
using DIP.Models;
using DIP.Repository;

namespace DIP.Services
{
    class InternLeaveManager : BaseLeaveManager
    {
        public InternLeaveManager(ILeaveRepository leaveRepository) : base(leaveRepository)
        {
        }
        public override bool Supports(Employee employee) => employee is InternEmployee;

        public override bool SupportsLeaveType(Employee employee, LeaveType leaveType)
        {
            // Interns can take only Unpaid Leave
            return leaveType == LeaveType.Unpaid;
        }
    }
}
