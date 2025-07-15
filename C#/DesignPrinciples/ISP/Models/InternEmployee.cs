namespace ISP.Models
{
    class InternEmployee : Employee
    {
        public InternEmployee(string name, LeaveBalance leaveBalance)
            : base(name, leaveBalance)
        {
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"[Intern] ID: {Id}, Name: {Name}");
        }
    }
}
