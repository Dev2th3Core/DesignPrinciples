using ISP.Interfaces;
using ISP.Models;

namespace ISP.Services
{
    class AttendanceManager
    {
        private List<IAttendanceManager> _attendanceStrategyList;

        public AttendanceManager(List<IAttendanceManager> attendanceStrategyList)
        {
            _attendanceStrategyList = attendanceStrategyList;
        }

        public Attendance MarkAttendance(Employee employee, Attendance attendance)
        {
            var strategy = GetStrategy(employee);
            return strategy.MarkAttendance(employee, attendance);
        }

        public bool ApproveAttendance(Guid attendanceId, Employee manager, Employee subordinate, bool approveAttendance)
        {
            return new PermanentAttendanceManager().ApproveAttendance(attendanceId, manager, subordinate, approveAttendance);
        }

        public List<Attendance> GetAttendancesByEmployee(Employee employee)
        {
            var strategy = GetStrategy(employee);
            return strategy.GetAttendancesByEmployee(employee);
        }

        private IAttendanceManager GetStrategy(Employee employee)
        {
            var strategy = _attendanceStrategyList.FirstOrDefault(s => s.Supports(employee));
            if (strategy == null)
                throw new InvalidOperationException("No leave strategy found for this employee type.");
            return strategy;
        }
    }
}
