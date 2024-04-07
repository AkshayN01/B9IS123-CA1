using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.DataAccess.Repositories;
using HotelManagementSystem.Library.Services.Data.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Admin.DataAccess.Repositories.Admin
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Permission> _dbSet;
        private readonly DbSet<PermissionAssignment> _dbSetPermissionAssignment;
        public PermissionRepository(DbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Permission>();
            _dbSetPermissionAssignment = _context.Set<PermissionAssignment>();
        }

        public async Task<List<Permission>> GetRolePermissionsAsync(int roleId, int branchId)
        {
            List<Permission> permissions = new List<Permission>();

            permissions = await _dbSetPermissionAssignment
                .Where(x => x.HotelBranchId == branchId && x.RoleId == roleId && !x.IsDeleted)
                .Select(x => x.Permission).ToListAsync();

            return permissions;
        }
    }
}
