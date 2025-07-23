using DIP.Enums;

namespace DIP.Models
{
    class PermanentEmployeeLeaveBalance : LeaveBalance
    {
        private Dictionary<LeaveType, int> leaveBalance;
        public PermanentEmployeeLeaveBalance()
        {
            leaveBalance = new Dictionary<LeaveType, int>
            {
                { LeaveType.Paid, 20 },
                { LeaveType.Unpaid, 60 },
                { LeaveType.Casual, 10 },
                { LeaveType.Sick, 15 }
            };
        }

        public override bool AddLeave(LeaveType type, int days)
        {
            if (!leaveBalance.ContainsKey(type)) return false;
            if (leaveBalance[type] >= days) { leaveBalance[type] += days; return true; }
            return false;
        }

        public override bool DeductLeave(LeaveType type, int days)
        {
            if (!leaveBalance.ContainsKey(type)) return false;
            if (leaveBalance[type] >= days) { leaveBalance[type] -= days; return true; }
            return false;
        }

        public override int GetLeaveBalance(LeaveType type)
        {
            return leaveBalance.ContainsKey(type) ? leaveBalance[type] : 0;
        }
    }
}
