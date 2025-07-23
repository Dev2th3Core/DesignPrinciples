using DIP.Interfaces;
using DIP.Models;
using DIP.Repository;

namespace DIP.Services
{
    public abstract class BaseAttendanceManager : IAttendanceManager
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public BaseAttendanceManager(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public List<Attendance> GetAttendancesByEmployee(Employee employee)
        {
            return _attendanceRepository.GetAllByEmployeeId(employee.Id);
        }

        public Attendance MarkAttendance(Employee employee, Attendance attendance)
        {
            // Prevent duplicate attendance for the same employee and date
            if (_attendanceRepository.IsAttendanceMarked(employee.Id, attendance.Date))
                throw new InvalidOperationException("Attendance already marked for this employee on this date.");

            Console.WriteLine($"Marking attendance for {employee.Name} on {attendance.Date.ToShortDateString()}.");
            _attendanceRepository.Add(attendance);
            return attendance;
        }

        public abstract bool Supports(Employee employee);
    }
}
