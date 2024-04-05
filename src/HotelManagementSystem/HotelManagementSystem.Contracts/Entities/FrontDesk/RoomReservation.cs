namespace HotelManagementSystem.Contracts.Entities.FrontDesk
{
    public class RoomReservation
    {
        public int RoomReservationId { get; set; }
        public int BookingId { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Double TotalAmount { get; set; }
        public int RoomStatusId { get; set; }
        public virtual RoomStatus RoomStatus { get; set; }
    }
}
