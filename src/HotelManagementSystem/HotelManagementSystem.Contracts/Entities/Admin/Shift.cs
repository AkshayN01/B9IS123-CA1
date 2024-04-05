namespace HotelManagementSystem.Contracts.Entities.Admin
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public string ShiftName { get; set; } = string.Empty;
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
