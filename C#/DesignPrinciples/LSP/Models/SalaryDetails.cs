namespace LSP.Models
{
    public class SalaryDetails
    {
        private Guid _employeeId;
        private double? _baseSalary;
        private double? _bonus;
        private double? _hourlyRate;
        private int? _hoursWorked;

        public Guid EmployeeId
        {
            get => _employeeId;
            private set
            {
                if (value == Guid.Empty)
                    throw new ArgumentException("EmployeeId cannot be an empty GUID.");
                _employeeId = value;
            }
        }

        public double? BaseSalary
        {
            get => _baseSalary;
            set
            {
                if (value.HasValue && value < 0)
                    throw new ArgumentException("BaseSalary cannot be negative.");
                _baseSalary = value;
            }
        }

        public double? Bonus
        {
            get => _bonus;
            set
            {
                if (value.HasValue && value < 0)
                    throw new ArgumentException("Bonus cannot be negative.");
                _bonus = value;
            }
        }

        public double? HourlyRate
        {
            get => _hourlyRate;
            set
            {
                if (value.HasValue && value < 0)
                    throw new ArgumentException("HourlyRate cannot be negative.");
                _hourlyRate = value;
            }
        }

        public int? HoursWorked
        {
            get => _hoursWorked;
            set
            {
                if (value.HasValue && value < 0)
                    throw new ArgumentException("HoursWorked cannot be negative.");
                _hoursWorked = value;
            }
        }

        public SalaryDetails(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
