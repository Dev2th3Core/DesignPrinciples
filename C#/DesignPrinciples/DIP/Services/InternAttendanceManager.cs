using DIP.Models;
using DIP.Repository;

namespace DIP.Services
{
    class InternAttendanceManager : BaseAttendanceManager
    {
        public InternAttendanceManager(IAttendanceRepository attendanceRepository) : base(attendanceRepository)
        {
        }

        public override bool Supports(Employee employee) => employee is InternEmployee;
    }
}
