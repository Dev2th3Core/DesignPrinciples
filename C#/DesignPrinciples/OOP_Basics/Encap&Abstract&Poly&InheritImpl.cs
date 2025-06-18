using OOP_Basics.Interface;

namespace OOP_Basics
{
    abstract class Employee
    {
        private int _id;
        private string _name;
        private double _salary;

        public int EmployeeId
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id must be greater than 0");
                }
                _id = value;
            }
        }

        public string EmployeeName
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                _name = value;
            }
        }

        public double Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative");
                }
                _salary = value;
            }
        }

        public Employee(int id, string name, double salary)
        {
            EmployeeId = id;
            EmployeeName = name;
            Salary = salary;
        }

        public void Display()
        {
            Console.WriteLine($"Id: {EmployeeId}, Name: {EmployeeName}");
        }

        public abstract void CalculatePay();
    }

    class PermanentEmployee : Employee, IPaidLeave, ICasualLeave
    {
        private int _paidLeaveCount = 15;
        private int _casualLeaveCount = 15;
        private string _role;

        public int PaidLeaveCount
        {
            get { return _paidLeaveCount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Paid Leave cannot be negative");
                }
                _paidLeaveCount = value;
            }
        }
        public int CasualLeaveCount
        {
            get { return _casualLeaveCount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Casual Leave cannot be negative");
                }
                _casualLeaveCount = value;
            }
        }
        public string Role
        {
            get { return _role; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Role cannot be null");
                }
            }
        }

        public List<Employee> Subordinates { get; set; }

        public PermanentEmployee(int id, string name, double salary, string role) : base(id, name, salary)
        {
            Role = role;
            Subordinates = new List<Employee>();
        }

        // Method Overriding
        public override void CalculatePay()
        {
            Console.WriteLine($"Employee {EmployeeName} earns a fixed salary of ${Salary}");
        }
        // Method Overloading
        public void CalculatePay(double bonus)
        {
            double total = Salary + bonus;
            Console.WriteLine($"Employee {EmployeeName} earns a salary of ${Salary} with bonus, total: ${total}");
        }
        public void CalculatePay(double bonus, double deduction)
        {
            double total = Salary + bonus - deduction;
            Console.WriteLine($"Employee {EmployeeName} earns a salary of ${Salary}, bonus: ${bonus}, deduction: ${deduction}, total: ${total}");
        }

        public void CancelLeave(int days)
        {
            Console.WriteLine($"{EmployeeName} has canceled {days} days of leave.");
        }

        void ICasualLeave.SubmitLeave(int days)
        {
            if (CasualLeaveCount >= days)
            {
                CasualLeaveCount -= days;
                Console.WriteLine($"{EmployeeName} has submitted {days} days of casual leave.");
            }
            else
            {
                Console.WriteLine($"Not enough casual leaves for {EmployeeName}.");
            }
        }

        void IPaidLeave.SubmitLeave(int days)
        {
            if (PaidLeaveCount >= days)
            {
                PaidLeaveCount -= days;
                Console.WriteLine($"{EmployeeName} has submitted {days} days of paid leave.");
            }
            else
            {
                Console.WriteLine($"Not enough paid leaves for {EmployeeName}.");
            }
        }

        public void ApproveLeave(int employeeId, int days)
        {
            if (Role != "Manager")
            {
                Console.WriteLine($"{EmployeeName} is not authorized to approve leave.");
                return;
            }

            var employee = Subordinates.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee == null)
            {
                Console.WriteLine($"{EmployeeName} does not manage an employee with ID {employeeId}.");
                return;
            }

            if (employee is IPaidLeave)
            {
                ((IPaidLeave)employee).SubmitLeave(days);
                Console.WriteLine($"{EmployeeName} approved {days} days of paid leave for {EmployeeName}.");
            }
            else if (employee is ICasualLeave)
            {
                ((ICasualLeave)employee).SubmitLeave(days);
                Console.WriteLine($"{EmployeeName} approved {days} days of casual leave for {EmployeeName}.");
            }
            else
            {
                Console.WriteLine($"{EmployeeName} cannot submit leave through the available interfaces.");
            }
        }
    }

    class ContractEmployee : Employee
    {
        private double _hourlyRate;
        private int _hoursWorked;
        public double HourlyRate
        {
            get { return _hourlyRate; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hourly Rate cannot be negative");
                }
                _hourlyRate = value;
            }
        }
        public int HoursWorked
        {
            get { return _hoursWorked; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hours Worked cannot be negative");
                }
                _hoursWorked = value;
            }
        }
        public ContractEmployee(int id, string name, double hourlyRate, int hoursWorked) : base(id, name, hourlyRate)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        // Method Overriding
        public override void CalculatePay()
        {
            double total = HourlyRate * HoursWorked;
            Console.WriteLine($"Contract Employee {EmployeeName} earns ${total} for {HoursWorked} hours of work at a rate of ${HourlyRate}/hour");
        }

        // Method Overloading
        public void CalculatePay(int extraHours)
        {
            int totalHours = HoursWorked + extraHours;
            double totalPay = HourlyRate * totalHours;
            Console.WriteLine($"Contract Employee {EmployeeName} with {extraHours} extra hours earned ${totalPay}");
        }
        public void CalculatePay(double hourlyBonus, int overtimeHours)
        {
            double totalRate = HourlyRate + hourlyBonus;
            int totalHours = HoursWorked + overtimeHours;
            double totalPay = totalRate * totalHours;
            Console.WriteLine($"Employee {EmployeeName} with overtime and bonus earned ${totalPay}");
        }
    }

}
