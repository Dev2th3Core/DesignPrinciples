using DIP.Models;

namespace DIP.Interfaces
{
    public interface IAttendanceManager
    {
        bool Supports(Employee employee);
        Attendance MarkAttendance(Employee employee, Attendance attendance);
        List<Attendance> GetAttendancesByEmployee(Employee employee);
    }
}
