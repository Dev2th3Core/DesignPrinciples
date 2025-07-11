using LSP.Models;

namespace LSP.Interfaces
{
    public interface IAttendanceTracker
    {
        bool Supports(Employee employee);
        Attendance MarkAttendance(Employee employee, Attendance attendance);
        bool ApproveAttendance(Guid attendanceId, Employee manager, Employee subordinate, bool approveAttendance);
        List<Attendance> GetAttendancesByEmployee(Employee employee);
    }
}
