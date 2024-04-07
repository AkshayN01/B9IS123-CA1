using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.DataAccess.Repositories;
using HotelManagementSystem.Library.Services.Data.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Admin.DataAccess.Repositories.Admin
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Role> _dbSet;
        private readonly DbSet<RoleAssignment> _dbSetRoleAssignment;
        public RoleRepository(DbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Role>();
            _dbSetRoleAssignment = _context.Set<RoleAssignment>();
        }
        public async Task<List<Role>> GetRoleByUserIdAsync(int userId, int branchId)
        {
            List<Role> role = new List<Role>();

            role = await _dbSetRoleAssignment
                .Where(x => x.HotelBranchId == branchId && x.UserId == userId && !x.IsDeleted)
                .Select(x => x.Role).ToListAsync();

            return role;
        }
    }
}
