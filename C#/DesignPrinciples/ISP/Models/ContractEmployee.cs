namespace ISP.Models
{
    public class ContractEmployee : Employee
    {
        public ContractEmployee(string name, LeaveBalance leaveBalance)
            : base(name, leaveBalance)
        {
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"[Contract] ID: {Id}, Name: {Name}");
        }
    }
}
