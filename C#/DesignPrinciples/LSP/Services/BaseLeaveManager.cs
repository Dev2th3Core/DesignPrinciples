using LSP.Enums;
using LSP.Interfaces;
using LSP.Models;

namespace LSP.Services
{
    public abstract class BaseLeaveManager : ILeaveManager
    {
        private readonly List<LeaveRequest> _leaveRequests = new();

        public LeaveRequest SubmitLeave(Employee employee, LeaveType type, int days)
        {
            if (!SupportsLeaveType(employee, type))
            {
                Console.WriteLine($"{employee.GetType().Name} cannot apply for {type} leave.");
                return null;
            }
            var request = new LeaveRequest(employee.Id, type, days);
            _leaveRequests.Add(request);

            Console.WriteLine($"{employee.Name} requested {days} day(s) of {type} leave. Request ID: {request.RequestId}");
            return request;
        }

        public void CancelLeave(Guid requestId, Employee employee)
        {
            _leaveRequests.RemoveAll(r => r.RequestId == requestId && r.EmployeeId == employee.Id && r.Status == LeaveStatus.Pending);
            Console.WriteLine($"Leave request with ID {requestId} has been cancelled by {employee.Name}.");
        }

        public bool ApproveLeave(Employee manager, Employee subordinate, Guid requestId, bool approveLeave)
        {
            if (subordinate.ManagerId != manager.Id)
            {
                Console.WriteLine($"{manager.Name} is not authorized to approve leave for {subordinate.Name}.");
                return false;
            }

            if (!approveLeave)
            {
                Console.WriteLine($"{manager.Name} rejected the leave request for {subordinate.Name}.");
                return false;
            }

            var request = _leaveRequests.FirstOrDefault(r =>
                r.RequestId == requestId &&
                r.EmployeeId == subordinate.Id &&
                r.Status == LeaveStatus.Pending);

            if (request == null)
            {
                Console.WriteLine($"No pending request with ID {requestId} found for {subordinate.Name}.");
                return false;
            }

            bool success = subordinate.LeaveBalance.DeductLeave(request.LeaveType, request.DaysRequested);
            if (success)
            {
                request.Status = LeaveStatus.Approved;
                request.ApprovedById = manager.Id;
                request.ApprovedOn = DateTime.Now;

                Console.WriteLine($"{manager.Name} approved {request.DaysRequested} day(s) of {request.LeaveType} leave for {subordinate.Name}.");
            }
            else
            {
                Console.WriteLine($"{subordinate.Name} does not have enough leave balance.");
            }

            return success;
        }

        public abstract bool SupportsLeaveType(Employee employee, LeaveType leaveType);
        public abstract bool Supports(Employee employee);
    }
}
