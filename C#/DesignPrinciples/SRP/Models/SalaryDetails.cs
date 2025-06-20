namespace SRP.Models
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

        public double CalculatePay()
        {
            if (BaseSalary.HasValue && Bonus.HasValue)
                return BaseSalary.Value + Bonus.Value;

            if (HourlyRate.HasValue && HoursWorked.HasValue)
                return HourlyRate.Value * HoursWorked.Value;

            throw new InvalidOperationException("Invalid salary data.");
        }
    }

}
