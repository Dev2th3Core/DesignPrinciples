using SRP.Enums;

namespace SRP.Models
{
    public class LeaveBalance
    {
        public int PaidLeaveRemaining { get; private set; } = 15;
        public int UnPaidLeaveRemaining { get; private set;} = 60;
        public int CasualLeaveRemaining { get; private set; } = 10;
        public int SickLeaveRemaining { get; private set; } = 5;

        public bool DeductLeave(LeaveType type, int days)
        {
            if (days <= 0) return false;

            switch (type)
            {
                case LeaveType.Paid when PaidLeaveRemaining >= days:
                    PaidLeaveRemaining -= days;
                    return true;
                case LeaveType.Paid when UnPaidLeaveRemaining >= days:
                    UnPaidLeaveRemaining -= days;
                    return true;
                case LeaveType.Casual when CasualLeaveRemaining >= days:
                    CasualLeaveRemaining -= days;
                    return true;
                case LeaveType.Sick when SickLeaveRemaining >= days:
                    SickLeaveRemaining -= days;
                    return true;
            }

            return false;
        }

        public void AddLeave(LeaveType type, int days)
        {
            if (days <= 0) return;

            switch (type)
            {
                case LeaveType.Paid:
                    PaidLeaveRemaining += days;
                    break;
                case LeaveType.Unpaid:
                    UnPaidLeaveRemaining += days;
                    break;
                case LeaveType.Casual:
                    CasualLeaveRemaining += days;
                    break;
                case LeaveType.Sick:
                    SickLeaveRemaining += days;
                    break;
            }
        }
    }

}
