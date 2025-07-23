namespace DIP.Models
{
    public class PermanentEmployee : Employee
    {
        public PermanentEmployee(string name, LeaveBalance leaveBalance)
            : base(name, leaveBalance)
        {
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"[Permanent] ID: {Id}, Name: {Name}");
        }
    }
}
