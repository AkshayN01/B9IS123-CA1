using HotelManagementSystem.FrontDesk.DataAccess;
using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library.Services.Data.FrontDesk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.FrontDesk.Blanket.Booking
{
    public class Booking
    {
        private readonly BookingService _service;
        public Booking(BookingService bookingService) 
        {
            _service = bookingService;
        }
    }
}
