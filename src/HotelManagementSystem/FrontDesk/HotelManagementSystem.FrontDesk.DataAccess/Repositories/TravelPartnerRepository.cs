using HotelManagementSystem.Contracts.Entities.FrontDesk;
using HotelManagementSystem.Library.Services.Data.FrontDesk;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.FrontDesk.DataAccess.Repositories
{
    public class TravelPartnerRepository : Repository<TravelPartner>, ITravelPartnerRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<TravelPartner> _travelPartnerSet;
        public TravelPartnerRepository(DbContext context) : base(context)
        {
            _context = context;
            _travelPartnerSet = _context.Set<TravelPartner>();
        }

        public async Task AddTravelPartners(List<TravelPartner> travelPartners)
        {
            foreach(TravelPartner travelPartner in travelPartners)
            {
                _context.Add<TravelPartner>(travelPartner);
            }
            await _context.SaveChangesAsync();
        }

        public IEnumerable<TravelPartner> GetByBookingId(int bookingId)
        {
            return _travelPartnerSet.Where(x => x.BookingId ==  bookingId).AsEnumerable();
        }
    }
}