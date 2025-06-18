namespace OOP_Basics.Interface
{
    interface ILeave
    {
        void CancelLeave(int days);
        void ApproveLeave(int employeeId, int days);
    }
}
