using LSP.Interfaces;
using LSP.Models;

namespace LSP.Services
{
    class AttendanceManager
    {
        private List<IAttendanceTracker> _attendanceStrategyList;

        public AttendanceManager(List<IAttendanceTracker> attendanceStrategyList)
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
            var strategy = GetStrategy(subordinate);
            return strategy.ApproveAttendance(attendanceId, manager, subordinate, approveAttendance);
        }

        public List<Attendance> GetAttendancesByEmployee(Employee employee)
        {
            var strategy = GetStrategy(employee);
            return strategy.GetAttendancesByEmployee(employee);
        }

        private IAttendanceTracker GetStrategy(Employee employee)
        {
            var strategy = _attendanceStrategyList.FirstOrDefault(s => s.Supports(employee));
            if (strategy == null)
                throw new InvalidOperationException("No leave strategy found for this employee type.");
            return strategy;
        }
    }
}
