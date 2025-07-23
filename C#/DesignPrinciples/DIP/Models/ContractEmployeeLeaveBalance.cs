using DIP.Enums;

namespace DIP.Models
{
    class ContractEmployeeLeaveBalance : LeaveBalance
    {
        private int unpaidLeaveBalance;
        public ContractEmployeeLeaveBalance()
        {
            unpaidLeaveBalance = 60;
        }

        public override bool AddLeave(LeaveType type, int days)
        {
            if (type != LeaveType.Unpaid || unpaidLeaveBalance < days) return false;
            unpaidLeaveBalance += days;
            return true;
        }

        public override bool DeductLeave(LeaveType type, int days)
        {
            if (type != LeaveType.Unpaid || unpaidLeaveBalance < days) return false;
            unpaidLeaveBalance -= days;
            return true;
        }

        public override int GetLeaveBalance(LeaveType type)
        {
            return type == LeaveType.Unpaid ? unpaidLeaveBalance : 0;
        }
    }
}
