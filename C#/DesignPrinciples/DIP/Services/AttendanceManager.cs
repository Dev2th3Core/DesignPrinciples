using DIP.Interfaces;
using DIP.Models;

namespace DIP.Services
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
            var strategy = GetStrategy(manager);
            if(strategy is IAttendanceApprover attendanceApprover)
            {
                return attendanceApprover.ApproveAttendance(attendanceId, manager, subordinate, approveAttendance);
            }
            else
            {
                throw new NotSupportedException("This employee type does not support attendance approval.");
            }
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
