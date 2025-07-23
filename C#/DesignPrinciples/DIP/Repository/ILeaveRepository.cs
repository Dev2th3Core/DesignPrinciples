using DIP.Models;

namespace DIP.Repository
{
    public interface ILeaveRepository
    {
        void AddLeaveRequest(LeaveRequest leaveRequest);
        void DeleteLeaveRequest(Guid leaveRequestId);
        LeaveRequest? GetLeaveRequestById(Guid leaveRequestId);
        List<LeaveRequest> GetAllLeaveRequestsByEmployeeId(Guid employeeId);
        bool IsLeaveRequestPending(Guid requestId, Guid employeeId, DateTime date);
        void ApproveLeaveRequest(Guid leaveRequestId);
    }
}
