using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.Library.Services.Data.Admin;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.DataAccess.Repositories.Admin
{
    public class HotelBranchRepository : Repository<HotelBranch>, IHotelBranchRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<HotelBranch> _dbSet;
        public HotelBranchRepository(DbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<HotelBranch>();
        }

        public Task<HotelBranch> GetCurrentBranchAsync()
        {
            return _dbSet.FirstOrDefaultAsync(x => x.IsCurrent == 1);
        }
    }
}
