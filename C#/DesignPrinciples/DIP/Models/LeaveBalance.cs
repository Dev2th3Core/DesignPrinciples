using DIP.Enums;

namespace DIP.Models
{
    public abstract class LeaveBalance
    {
        public abstract int GetLeaveBalance(LeaveType type);
        public abstract bool AddLeave(LeaveType type, int days);
        public abstract bool DeductLeave(LeaveType type, int days);
    }
}
