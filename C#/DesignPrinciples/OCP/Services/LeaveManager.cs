using OCP.Enums;
using OCP.Interfaces;
using OCP.Models;

namespace OCP.Services
{
    public class LeaveManager
    {
        private List<ILeaveManager> _leaveStrategyList;

        public LeaveManager(List<ILeaveManager> leaveStrategyList)
        {
            _leaveStrategyList = leaveStrategyList;
        }

        public LeaveRequest SubmitLeave(Employee employee, LeaveType type, int days)
        {
            var strategy = GetStrategy(employee);
            return strategy.SubmitLeave(employee, type, days);
        }

        public void CancelLeave(Guid requestId, Employee employee)
        {
            var strategy = GetStrategy(employee);
            strategy.CancelLeave(requestId, employee);
        }

        public bool ApproveLeave(Employee manager, Employee subordinate, Guid requestId, bool approveLeave)
        {
            var strategy = GetStrategy(subordinate);
            return strategy.ApproveLeave(manager, subordinate, requestId, approveLeave);
        }

        private ILeaveManager GetStrategy(Employee employee)
        {
            var strategy = _leaveStrategyList.FirstOrDefault(s => s.Supports(employee));
            if (strategy == null)
                throw new InvalidOperationException("No leave strategy found for this employee type.");
            return strategy;
        }
    }
}
