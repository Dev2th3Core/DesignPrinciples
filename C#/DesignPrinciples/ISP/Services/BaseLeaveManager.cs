using ISP.Enums;
using ISP.Interfaces;
using ISP.Models;

namespace ISP.Services
{
    public abstract class BaseLeaveManager : ILeaveManager
    {
        protected static readonly List<LeaveRequest> _leaveRequests = new();

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

        public abstract bool SupportsLeaveType(Employee employee, LeaveType leaveType);
        public abstract bool Supports(Employee employee);
    }
}
