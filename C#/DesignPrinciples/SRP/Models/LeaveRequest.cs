using SRP.Enums;

namespace SRP.Models
{
    public class LeaveRequest
    {
        private Guid _requestId;
        private Guid _employeeId;
        private LeaveType _leaveType;
        private int _daysRequested;
        private string _status;
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

        public string Status
        {
            get => _status;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Status cannot be null or empty.");
                }
                _status = value;
            }
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
            Status = "Pending";
            RequestedOn = DateTime.Now;
        }
    }
}
