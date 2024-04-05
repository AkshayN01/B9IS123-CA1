namespace HotelManagementSystem.Contracts.Entities.FrontDesk
{
    internal class Booking
    {
        public int BookingId { get; set; }
        public int VisitorId { get; set; }
        public DateTime BookingDate { get; set; }
        public int BookinStatusId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
