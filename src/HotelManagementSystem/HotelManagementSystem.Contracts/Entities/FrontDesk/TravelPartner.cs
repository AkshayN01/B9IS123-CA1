using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Contracts.Entities.FrontDesk
{
    internal class TravelPartner
    {
        [Key]
        public int Id { get; set; }
        public int VisitorId { get; set; }
        public int VisitorPartnerId { get; set; }
        public int BookingId { get; set; }
    }
}
