using ISP.Models;

namespace ISP.Services
{
    class InternAttendanceManager : BaseAttendanceManager
    {
        public override bool Supports(Employee employee) => employee is InternEmployee;
    }
}
