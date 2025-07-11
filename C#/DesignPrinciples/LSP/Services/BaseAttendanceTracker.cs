using LSP.Interfaces;
using LSP.Models;

namespace LSP.Services
{
    public abstract class BaseAttendanceTracker : IAttendanceTracker
    {
        private readonly List<Attendance> _attendanceList = new();

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
