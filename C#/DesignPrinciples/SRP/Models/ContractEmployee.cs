namespace SRP.Models
{
    public class ContractEmployee : Employee
    {
        public ContractEmployee(string name)
            : base(name)
        {
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"[Contract] ID: {Id}, Name: {Name}");
        }
    }
}
