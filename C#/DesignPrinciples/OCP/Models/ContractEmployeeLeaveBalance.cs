using OCP.Enums;

namespace OCP.Models
{
    class ContractEmployeeLeaveBalance : LeaveBalance
    {
        private int _unpaidLeaveBalance;

        public int UnpaidLeaveBalance
        {
            get => _unpaidLeaveBalance;
            set
            {
                if(value < 0)
                    throw new ArgumentException("Unpaid leave balance cannot be negative.");
                _unpaidLeaveBalance = value;
            }
        }
        public ContractEmployeeLeaveBalance()
        {
            UnpaidLeaveBalance = 60;
        }

        public override bool AddLeave(LeaveType type, int days)
        {
            if (type != LeaveType.Unpaid || UnpaidLeaveBalance < days) return false;
            UnpaidLeaveBalance += days;
            return true;
        }

        public override bool DeductLeave(LeaveType type, int days)
        {
            if (type != LeaveType.Unpaid || UnpaidLeaveBalance < days) return false;
            UnpaidLeaveBalance -= days;
            return true;
        }

        public override int GetLeaveBalance(LeaveType type)
        {
            return type == LeaveType.Unpaid ? UnpaidLeaveBalance : 0;
        }
    }
}
