using OCP.Enums;
using OCP.Models;

namespace OCP.Interfaces
{
    public interface ILeaveManager
    {
        bool Supports(Employee employee);
        LeaveRequest SubmitLeave(Employee employee, LeaveType type, int days);
        void CancelLeave(Guid requestId, Employee employeeId);
        bool ApproveLeave(Employee manager, Employee subordinate, Guid requestId, bool approveLeave);
        bool SupportsLeaveType(Employee employee, LeaveType leaveType);
    }
}
