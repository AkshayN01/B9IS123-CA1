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

        public async Task<int> AddRoleAsync(Role role)
        {
            _context.Add<Role>(role);
            await _context.SaveChangesAsync();
            return role.RoleId;
        }

        public async Task<List<Role>> GetRoleByBranchIdAsync(int branchId)
        {
            return await _dbSet.Where(x => x.HotelBranchId == branchId).ToListAsync();
        }

        public async Task<List<Role>> GetRoleByUserIdAsync(int userId, int branchId)
        {
            List<Role> role = new List<Role>();

            role = await _dbSetRoleAssignment
                .Where(x => x.HotelBranchId == branchId && x.UserId == userId && !x.IsDeleted)
                .Select(x => x.Role).ToListAsync();

            return role;
        }

        public async Task<int> AssignRoleToAUser(RoleAssignment roleAssignment)
        {
            int retVal = 0;

            try
            {
                _context.Add<RoleAssignment>(roleAssignment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { }

            return retVal;
        }
    }
}