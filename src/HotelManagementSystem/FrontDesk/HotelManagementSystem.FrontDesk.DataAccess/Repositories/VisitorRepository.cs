using HotelManagementSystem.Contracts.Entities.Admin;
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
        private readonly DbSet<Visitor> _dbSet;
        public VisitorRepository(DbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Visitor>();
        }

        public async Task<int> AddVisitorDetails(Visitor visitor)
        {
            _context.Add<Visitor>(visitor);
            await _context.SaveChangesAsync();
            return visitor.VisitorId;
        }

        public async Task<List<int>> AddMultipleVisitors(List<Visitor> visitors)
        {
            foreach (var visitor in visitors)
            {
                _context.Add<Visitor>(visitor);
            }
            await _context.SaveChangesAsync();
            return visitors.Select(x => x.VisitorId).ToList();
        }
        public IEnumerable<Visitor> GetAllVisitors(List<int> visitorIds)
        {
            IEnumerable<Visitor> result;

            result = _dbSet.Where(x => visitorIds.Contains(x.VisitorId)).AsEnumerable<Visitor>();

            return result;
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