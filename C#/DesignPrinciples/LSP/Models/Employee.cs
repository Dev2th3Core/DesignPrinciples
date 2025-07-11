namespace LSP.Models
{
    public abstract class Employee
    {
        private Guid _id;
        private string _name;
        private Guid? _managerId;

        public Guid Id
        {
            get => _id;
            set
            {
                if (value == Guid.Empty)
                    throw new ArgumentException("ID must be a non-empty GUID.");
                _id = value;
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                _name = value;
            }
        }

        public Guid? ManagerId
        {
            get => _managerId;
            set
            {
                if (value == Guid.Empty)
                    throw new ArgumentException("Manager ID must be a non-empty GUID.");
                _managerId = value;
            }
        }

        public LeaveBalance LeaveBalance { get; set; }

        protected Employee(string name, LeaveBalance leaveBalance)
        {
            Id = Guid.NewGuid();
            Name = name;
            LeaveBalance = leaveBalance;
        }

        public abstract void DisplayDetails();
    }
}
