using DIP.Enums;
using DIP.Interfaces;
using DIP.Models;
using DIP.Repository;

namespace DIP.Services
{
    public abstract class BaseLeaveManager : ILeaveManager
    {
        private readonly ILeaveRepository _leaveRepository;

        public BaseLeaveManager(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        public LeaveRequest SubmitLeave(Employee employee, LeaveType type, int days)
        {
            if (!SupportsLeaveType(employee, type))
            {
                Console.WriteLine($"{employee.GetType().Name} cannot apply for {type} leave.");
                return null;
            }
            var request = new LeaveRequest(employee.Id, type, days);
            _leaveRepository.AddLeaveRequest(request);

            Console.WriteLine($"{employee.Name} requested {days} day(s) of {type} leave. Request ID: {request.RequestId}");
            return request;
        }

        public void CancelLeave(Guid requestId, Employee employee)
        {
            _leaveRepository.DeleteLeaveRequest(requestId);
            Console.WriteLine($"Leave request with ID {requestId} has been cancelled by {employee.Name}.");
        }

        public abstract bool SupportsLeaveType(Employee employee, LeaveType leaveType);
        public abstract bool Supports(Employee employee);
    }
}
