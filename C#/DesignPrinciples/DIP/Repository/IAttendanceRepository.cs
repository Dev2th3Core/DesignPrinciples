using DIP.Enums;
using DIP.Models;

namespace DIP.Repository
{
    public interface IAttendanceRepository
    {
        void Add(Attendance attendance);
        void Update(Attendance attendance);
        void Delete(Guid attendanceId);
        Attendance? GetById(Guid attendanceId);
        List<Attendance> GetAllByEmployeeId(Guid employeeId);
        bool IsAttendanceMarked(Guid employeeId, DateTime date);
        public void MarkAttendance(Guid employeeId, DateTime date, int workingHours, AttendanceType attendanceType);
    }
}
