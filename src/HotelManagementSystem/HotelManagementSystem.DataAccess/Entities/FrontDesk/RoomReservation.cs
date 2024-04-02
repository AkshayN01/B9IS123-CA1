using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DataAccess.Entities.FrontDesk
{
    internal class RoomReservation
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
        public virtual Room Room { get; set; }
        public virtual Booking Booking { get; set; } 
    }
}
