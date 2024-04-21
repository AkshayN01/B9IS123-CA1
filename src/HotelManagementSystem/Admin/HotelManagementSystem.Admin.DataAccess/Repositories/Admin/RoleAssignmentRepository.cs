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
    public class RoleAssignmentRepository : Repository<RoleAssignment>, IRoleAssignmentRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Role> _dbSet;
        private readonly DbSet<RoleAssignment> _dbSetRoleAssignment;
        public RoleAssignmentRepository(DbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Role>();
            _dbSetRoleAssignment = _context.Set<RoleAssignment>();
        }

        public async Task<RoleAssignment> GetRoleAssignmentByUserId(int userId)
        {
            return await _dbSetRoleAssignment.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
