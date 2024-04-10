using HotelManagementSystem.Contracts.Entities.FrontDesk;
using HotelManagementSystem.Contracts.Entities.Visitor;
using HotelManagementSystem.Library.Services.Data.FrontDesk;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.FrontDesk.DataAccess.Repositories
{
    public class VisitorRepository : Repository<Visitor>, IVisitorRepository
    {
        private readonly DbContext _context;
        public VisitorRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Visitor> GetByBookingId(int branchId, int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Visitor>> GetTravelPartner(int visitorId, int bookingId)
        {
            throw new NotImplementedException();
        }
    }
}
