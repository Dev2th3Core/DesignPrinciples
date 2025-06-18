using OOP_Basics.Interface;

namespace OOP_Basics
{
    class Encap_Abstract_Poly_Inherit
    {
        public static void Invoke()
        {
            Console.WriteLine("Encapsulation, Abstraction, Polymorphism and Inheritance");

            // Single-Level Inheritance
            PermanentEmployee emp1 = new PermanentEmployee(201, "Sophia", 82000, "Employee");
            emp1.Display();         // From base class: Employee
            emp1.CalculatePay();    // Overridden in PermanentEmployee

            // Multi-Level Inheritance
            PermanentEmployee emp2 = new PermanentEmployee(202, "Liam", 87000, "Employee");
            emp2.Display();
            // IPaidLeave and ICasualLeave inherit ILeave
            ((IPaidLeave)emp2).SubmitLeave(3);       // From IPaidLeave
            ((ICasualLeave)emp2).SubmitLeave(2);     // From ICasualLeave
            emp2.CancelLeave(2);           // From ILeave (inherited via IPaidLeave/ICasualLeave)

            // Multi-Level Inheritance (Interface-based)
            PermanentEmployee manager1 = new PermanentEmployee(203, "Olivia", 98000, "Manager");
            manager1.Display();
            ((IPaidLeave)manager1).SubmitLeave(4);      // IPaidLeave
            ((ICasualLeave)manager1).SubmitLeave(2);    // ICasualLeave
            manager1.CancelLeave(2);          // Common from ILeave

            // Hierarchical Inheritance
            Employee emp3 = new PermanentEmployee(204, "Noah", 79000, "Employee");
            Employee emp4 = new ContractEmployee(205, "Emma", 75, 7);

            emp3.Display();         // From Employee
            emp3.CalculatePay();    // Overridden in PermanentEmployee

            emp4.Display();         // From Employee
            emp4.CalculatePay();    // Overridden in ContractEmployee

            // Simple Manager-Subordinate Leave Approval
            PermanentEmployee manager2 = new PermanentEmployee(206, "James", 102000, "Manager");
            manager2.Display();
            PermanentEmployee emp5 = new PermanentEmployee(207, "Ava", 76000, "Employee");
            emp5.Display();
            PermanentEmployee emp6 = new PermanentEmployee(208, "Lucas", 74000, "Employee");
            emp6.Display();

            manager2.Subordinates.Add(emp5);
            manager2.Subordinates.Add(emp6);

            // Manager approves leave
            manager2.ApproveLeave(207, 3);   // Approves for Ava

        }
    }

}
