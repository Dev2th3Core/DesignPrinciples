using DIP.Models;
using DIP.Repository;

namespace DIP.Services
{
    class ContractAttendanceManager : BaseAttendanceManager
    {
        public ContractAttendanceManager(IAttendanceRepository attendanceRepository) : base(attendanceRepository)
        {
        }

        public override bool Supports(Employee employee) => employee is ContractEmployee;
    }
}
