using ISP.Models;

namespace ISP.Interfaces
{
    public interface ILeaveApprover
    {
        bool ApproveLeave(Employee manager, Employee subordinate, Guid requestId, bool approveLeave);
    }
}
