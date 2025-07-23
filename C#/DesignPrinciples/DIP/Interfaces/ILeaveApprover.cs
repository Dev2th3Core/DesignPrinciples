using DIP.Models;

namespace DIP.Interfaces
{
    public interface ILeaveApprover
    {
        bool ApproveLeave(Employee manager, Employee subordinate, Guid requestId, bool approveLeave);
    }
}
