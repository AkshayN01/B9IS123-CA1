using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Contracts.Entities.FrontDesk
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int VisitorId { get; set; }
        public int Branchd {  get; set; }
        public DateTime BookingFromDate { get; set; }
        public DateTime BookingToDate { get; set; }
        public int BookinStatusId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public ICollection<RoomReservation> Reservations { get; set; } = new List<RoomReservation>();
        public ICollection<TravelPartner> TravelPartners { get; set; } = new List<TravelPartner>();
    }
}
