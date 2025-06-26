namespace OCP.Models
{
    public class PermanentEmployee : Employee
    {

        public PermanentEmployee(string name)
            : base(name)
        {
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"[Permanent] ID: {Id}, Name: {Name}");
        }
    }
}
