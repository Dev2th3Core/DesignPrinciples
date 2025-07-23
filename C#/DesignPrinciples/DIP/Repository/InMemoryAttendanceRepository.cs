using DIP.Enums;
using DIP.Models;

namespace DIP.Repository
{
    class InMemoryAttendanceRepository : IAttendanceRepository
    {
        private readonly List<Attendance> _attendances = new();
        public void Add(Attendance attendance)
        {
            _attendances.Add(attendance);
        }

        public void Delete(Guid attendanceId)
        {
            _attendances.RemoveAll(a => a.Id == attendanceId);
        }

        public List<Attendance> GetAllByEmployeeId(Guid employeeId)
        {
            return _attendances.Where(a => a.EmployeeId == employeeId).ToList();
        }

        public Attendance? GetById(Guid attendanceId)
        {
            return _attendances.FirstOrDefault(a => a.Id == attendanceId);
        }

        public bool IsAttendanceMarked(Guid employeeId, DateTime date)
        {
            return _attendances.Any(a => a.EmployeeId == employeeId && a.Date.Date == date.Date);
        }

        public void Update(Attendance attendance)
        {
            var existingAttendance = GetById(attendance.Id);
            if (existingAttendance != null)
            {
                existingAttendance.Date = attendance.Date;
                existingAttendance.Approved = attendance.Approved;
                existingAttendance.WorkingHours = attendance.WorkingHours;
                existingAttendance.AttendanceType = attendance.AttendanceType;
            }
            else
            {
                throw new InvalidOperationException("Attendance not found.");
            }
        }
        public void MarkAttendance(Guid employeeId, DateTime date, int workingHours, AttendanceType attendanceType)
        {
            var existingAttendance = _attendances.FirstOrDefault(a => a.EmployeeId == employeeId && a.Date.Date == date.Date);
            if (existingAttendance is null)
            {
                throw new InvalidOperationException($"Attendance not found for the given employee with id {employeeId} and on date {date}.");
            }
            else if (existingAttendance.Approved)
            {
                throw new InvalidOperationException("Attendance already approved, cannot mark again.");
            }
            else
            {
                existingAttendance.WorkingHours = workingHours;
                existingAttendance.AttendanceType = attendanceType;
                existingAttendance.Approved = true;
            }
        }
    }
}
