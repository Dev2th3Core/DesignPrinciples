using DIP.Models;

namespace DIP.Interfaces
{
    interface IAttendanceApprover
    {
        bool ApproveAttendance(Guid attendanceId, Employee manager, Employee subordinate, bool approveAttendance);
    }
}
