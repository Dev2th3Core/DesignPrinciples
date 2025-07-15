using ISP.Models;

namespace ISP.Interfaces
{
    public interface IAttendanceManager
    {
        bool Supports(Employee employee);
        Attendance MarkAttendance(Employee employee, Attendance attendance);
        List<Attendance> GetAttendancesByEmployee(Employee employee);
    }
}
