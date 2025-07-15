using ISP.Enums;
using ISP.Models;

namespace ISP.Interfaces
{
    public interface ILeaveManager
    {
        bool Supports(Employee employee);
        LeaveRequest SubmitLeave(Employee employee, LeaveType type, int days);
        void CancelLeave(Guid requestId, Employee employeeId);
        bool SupportsLeaveType(Employee employee, LeaveType leaveType);
    }
}
