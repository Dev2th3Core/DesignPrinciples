using DIP.Enums;
using DIP.Interfaces;
using DIP.Models;
using DIP.Repository;

namespace DIP.Services
{
    class PermanentLeaveManager : BaseLeaveManager, ILeaveApprover
    {
        private readonly ILeaveRepository _leaveRepository;
        public PermanentLeaveManager(ILeaveRepository leaveRepository) : base(leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        public override bool Supports(Employee employee) => employee is PermanentEmployee;

        public override bool SupportsLeaveType(Employee employee, LeaveType leaveType)
        {
            return true; // Permanent employees can take all types of leave
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

            var request = _leaveRepository.GetLeaveRequestById(requestId);

            if (request == null)
            {
                Console.WriteLine($"No pending request with ID {requestId} found for {subordinate.Name}.");
                return false;
            }

            bool success = subordinate.LeaveBalance.DeductLeave(request.LeaveType, request.DaysRequested);
            if (success)
            {
                _leaveRepository.ApproveLeaveRequest(requestId);

                Console.WriteLine($"{manager.Name} approved {request.DaysRequested} day(s) of {request.LeaveType} leave for {subordinate.Name}.");
            }
            else
            {
                Console.WriteLine($"{subordinate.Name} does not have enough leave balance.");
            }

            return success;
        }
    }
}
