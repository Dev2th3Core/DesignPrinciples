using ISP.Interfaces;
using ISP.Models;

namespace ISP.Services
{
    class PermanentAttendanceManager : BaseAttendanceManager, IAttendanceApprover
    {
        public override bool Supports(Employee employee) => employee is PermanentEmployee;

        public bool ApproveAttendance(Guid attendanceId, Employee manager, Employee subordinate, bool approveAttendance)
        {
            if (subordinate.ManagerId != manager.Id)
            {
                Console.WriteLine($"{manager.Name} is not authorized to approve attendance for {subordinate.Name}.");
                return false;
            }

            if (!approveAttendance)
            {
                Console.WriteLine($"{manager.Name} rejected the attendance for {subordinate.Name}.");
                return false;
            }

            var request = _attendanceList.FirstOrDefault(r =>
                r.Id == attendanceId &&
                r.EmployeeId == subordinate.Id);

            if (request == null)
            {
                Console.WriteLine($"No pending Attendance with ID {attendanceId} found for {subordinate.Name}.");
                return false;
            }

            request.Approved = true;
            Console.WriteLine($"{manager.Name} approved the attendance for {subordinate.Name} on {request.Date.ToShortDateString()}.");
            return true;
        }
    }
}
