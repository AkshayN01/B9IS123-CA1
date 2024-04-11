namespace HotelManagementSystem.Contracts.Entities.FrontDesk
{
    public class RoomReservation
    {
        public int RoomReservationId { get; set; }
        public int BookingId { get; set; }
        public int BranchId { get; set; }
        public string UserGuid { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Double TotalAmount { get; set; }
        public int IsActive { get; set; }
        public int RoomStatusId { get; set; }
        public Booking Booking { get; set; } = null!;
        public Room Room { get; set; } = null!;
    }
}
