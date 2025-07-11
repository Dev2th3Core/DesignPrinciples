using LSP.Models;

namespace LSP.Services
{
    class PermanentAttendanceTracker : BaseAttendanceTracker
    {
        public override bool Supports(Employee employee) => employee is PermanentEmployee;
    }
}
