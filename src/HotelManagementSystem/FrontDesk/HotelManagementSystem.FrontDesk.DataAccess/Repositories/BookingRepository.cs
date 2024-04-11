using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.Contracts.Entities.FrontDesk;
using HotelManagementSystem.Library.Services.Data.Admin;
using HotelManagementSystem.Library.Services.Data.FrontDesk;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.FrontDesk.DataAccess.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly DbContext _context;
        public BookingRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> AddBookingDetails(Booking booking)
        {
            _context.Add<Booking>(booking);
            await _context.SaveChangesAsync();
            return booking.BookingId;
        }
    }
}