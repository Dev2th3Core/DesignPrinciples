using DIP.Enums;
using DIP.Models;

namespace DIP.Repository
{
    class InMemoryLeaveRepository : ILeaveRepository
    {
        private readonly List<LeaveRequest> _leaveRequests = new(); 
        public void AddLeaveRequest(LeaveRequest leaveRequest)
        {
            _leaveRequests.Add(leaveRequest);
        }

        public void ApproveLeaveRequest(Guid leaveRequestId)
        {
            var existingRequest = _leaveRequests.FirstOrDefault(lr => lr.RequestId == leaveRequestId);
            if(existingRequest is null)
            {
                throw new InvalidOperationException("Leave request not found.");
            }
            else if(existingRequest.Status == LeaveStatus.Approved)
            {
                throw new InvalidOperationException("Leave request already approved.");
            }
            else
            {
                existingRequest.Status = LeaveStatus.Approved;
            }
        }

        public void DeleteLeaveRequest(Guid leaveRequestId)
        {
            _leaveRequests.RemoveAll(lr => lr.RequestId == leaveRequestId);
        }

        public List<LeaveRequest> GetAllLeaveRequestsByEmployeeId(Guid employeeId)
        {
            return _leaveRequests.Where(lr => lr.EmployeeId == employeeId).ToList();
        }

        public LeaveRequest? GetLeaveRequestById(Guid leaveRequestId)
        {
            return _leaveRequests.FirstOrDefault(lr => lr.RequestId == leaveRequestId);
        }

        public bool IsLeaveRequestPending(Guid requestId, Guid employeeId, DateTime date)
        {
            return _leaveRequests.Any(lr => lr.EmployeeId == employeeId && lr.Status != LeaveStatus.Approved);
        }
    }
}
