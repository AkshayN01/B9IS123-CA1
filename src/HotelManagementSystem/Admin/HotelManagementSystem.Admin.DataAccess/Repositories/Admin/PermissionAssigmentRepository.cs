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
    public class PermissionAssignmentRepository : Repository<PermissionAssignment>, IPermissionAssignmentRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Role> _dbSet;
        private readonly DbSet<PermissionAssignment> _dbSetPermissionAssignment;
        public PermissionAssignmentRepository(DbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Role>();
            _dbSetPermissionAssignment = _context.Set<PermissionAssignment>();
        }

        public async Task<int> AddPermissionAssignmentAsync(List<PermissionAssignment> permissionAssignments)
        {
            try
            {
                foreach (var permission in permissionAssignments)
                {
                    _context.Add<PermissionAssignment>(permission);
                }
                await _context.SaveChangesAsync();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}