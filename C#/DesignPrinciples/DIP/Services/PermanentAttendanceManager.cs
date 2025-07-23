using DIP.Interfaces;
using DIP.Models;
using DIP.Repository;

namespace DIP.Services
{
    class PermanentAttendanceManager : BaseAttendanceManager, IAttendanceApprover
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public PermanentAttendanceManager(IAttendanceRepository attendanceRepository) : base(attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public override bool Supports(Employee employee) => employee is PermanentEmployee;

        public bool ApproveAttendance(Guid attendanceId, Employee manager, Employee subordinate, bool approveAttendance)
        {
            if (subordinate.ManagerId != manager.Id)
            {
                Console.WriteLine($"{manager.Name} is not authorized to approve attendance for {subordinate.Name}.");
                return false;
            }

            if (!approveAttendance)
            {
                Console.WriteLine($"{manager.Name} rejected the attendance for {subordinate.Name}.");
                return false;
            }

            var request = _attendanceRepository.GetById(attendanceId);

            if (request == null)
            {
                Console.WriteLine($"No pending Attendance with ID {attendanceId} found for {subordinate.Name}.");
                return false;
            }

            _attendanceRepository.MarkAttendance(subordinate.Id, request.Date, request.WorkingHours, request.AttendanceType);
            Console.WriteLine($"{manager.Name} approved the attendance for {subordinate.Name} on {request.Date.ToShortDateString()}.");
            return true;
        }
    }
}
