using ISP.Interfaces;
using ISP.Models;

namespace ISP.Services
{
    public abstract class BaseAttendanceManager : IAttendanceManager
    {
        protected static readonly List<Attendance> _attendanceList = new();

        public List<Attendance> GetAttendancesByEmployee(Employee employee)
        {
            return _attendanceList.Where(a => a.EmployeeId == employee.Id).ToList();
        }

        public Attendance MarkAttendance(Employee employee, Attendance attendance)
        {
            // Prevent duplicate attendance for the same employee and date
            if (_attendanceList.Any(a => a.EmployeeId == attendance.EmployeeId && a.Date.Date == attendance.Date.Date))
                throw new InvalidOperationException("Attendance already marked for this employee on this date.");

            Console.WriteLine($"Marking attendance for {employee.Name} on {attendance.Date.ToShortDateString()}.");
            _attendanceList.Add(attendance);
            return attendance;
        }

        public abstract bool Supports(Employee employee);
    }
}
