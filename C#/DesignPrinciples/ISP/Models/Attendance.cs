using ISP.Enums;

namespace ISP.Models
{
    public class Attendance
    {

        private Guid _attendanceId;
        private Guid _employeeId;
        private DateTime _date;
        private int _workingHours;
        private bool _approved = false;
        private AttendanceType _attendanceType;
        public Guid Id 
        {
            get => _attendanceId; 
            set
            {
                if (value == Guid.Empty)
                    throw new ArgumentException("ID must be a non-empty GUID.");
                _attendanceId = value;
            }
        }
        public Guid EmployeeId
        {
            get => _employeeId;
            set
            {
                if (value == Guid.Empty)
                    throw new ArgumentException("Employee ID must be a non-empty GUID.");
                _employeeId = value;
            }
        }
        public DateTime Date 
        { 
            get => _date;
            set
            {
                if(value == default)
                    throw new ArgumentException("Date must be a valid value.");
                _date = value;
            }
        }
        public int WorkingHours 
        { 
            get => _workingHours;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Working hours cannot be negative.");
                _workingHours = value;
            }
        }
        public bool Approved
        {
            get => _approved;
            set => _approved = value;
        }
        public AttendanceType AttendanceType
        {
            get => _attendanceType;
            set => _attendanceType = value;
        }
        public Attendance(Guid employeeId, DateTime date, int workingHours, AttendanceType attendanceType)
        {
            Id = Guid.NewGuid();
            EmployeeId = employeeId;
            Date = date;
            WorkingHours = workingHours;
            AttendanceType = attendanceType;
        }
    }
}
