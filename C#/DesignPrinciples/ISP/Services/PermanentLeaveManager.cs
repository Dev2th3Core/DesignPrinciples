using ISP.Enums;
using ISP.Interfaces;
using ISP.Models;

namespace ISP.Services
{
    class PermanentLeaveManager : BaseLeaveManager, ILeaveApprover
    {
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
    }
}
