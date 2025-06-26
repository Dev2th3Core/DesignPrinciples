namespace OCP.Models
{
    public class SalaryDetails
    {
        public Guid EmployeeId { get; set; }
        public double? BaseSalary { get; set; }
        public double? Bonus { get; set; }
        public double? HourlyRate { get; set; }
        public int? HoursWorked { get; set; }

        public SalaryDetails(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
