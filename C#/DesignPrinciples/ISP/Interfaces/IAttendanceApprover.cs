using ISP.Models;

namespace ISP.Interfaces
{
    interface IAttendanceApprover
    {
        bool ApproveAttendance(Guid attendanceId, Employee manager, Employee subordinate, bool approveAttendance);
    }
}
