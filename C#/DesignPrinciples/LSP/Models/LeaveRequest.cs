using LSP.Enums;

namespace LSP.Models
{
    public class LeaveRequest
    {
        private Guid _requestId;
        private Guid _employeeId;
        private LeaveType _leaveType;
        private int _daysRequested;
        private LeaveStatus _status;
        private Guid? _approvedById;
        private DateTime _requestedOn;
        private DateTime? _approvedOn;

        public Guid RequestId
        {
            get => _requestId;
            set
            {
                if (value == Guid.Empty)
                {
                    throw new ArgumentException("RequestId cannot be an empty GUID.");
                }
                _requestId = value;
            }
        }

        public Guid EmployeeId
        {
            get => _employeeId;
            set
            {
                if (value == Guid.Empty)
                {
                    throw new ArgumentException("EmployeeId cannot be an empty GUID.");
                }
                _employeeId = value;
            }
        }

        public LeaveType LeaveType
        {
            get => _leaveType;
            private set => _leaveType = value;
        }

        public int DaysRequested
        {
            get => _daysRequested;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("DaysRequested must be greater than zero.");
                }
                _daysRequested = value;
            }
        }

        public LeaveStatus Status
        {
            get => _status;
            set => _status = value;
        }

        public Guid? ApprovedById
        {
            get => _approvedById;
            set
            {
                if (value.HasValue && value == Guid.Empty)
                {
                    throw new ArgumentException("ApprovedById cannot be an empty GUID.");
                }
                _approvedById = value;
            }
        }

        public DateTime RequestedOn
        {
            get => _requestedOn;
            set
            {
                if (value == default)
                {
                    throw new ArgumentException("RequestedOn must be a valid date.");
                }
                _requestedOn = value;
            }
        }

        public DateTime? ApprovedOn
        {
            get => _approvedOn;
            set
            {
                if (value.HasValue && value == DateTime.UtcNow)
                {
                    throw new ArgumentException("ApprovedOn must be a valid date.");
                }
                _approvedOn = value;
            }
        }

        public LeaveRequest(Guid employeeId, LeaveType type, int days)
        {
            RequestId = Guid.NewGuid();
            EmployeeId = employeeId;
            LeaveType = type;
            DaysRequested = days;
            Status = LeaveStatus.Pending;
            RequestedOn = DateTime.Now;
        }
    }
}
