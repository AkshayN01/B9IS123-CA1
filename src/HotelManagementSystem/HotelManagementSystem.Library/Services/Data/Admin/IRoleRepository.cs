using HotelManagementSystem.Contracts.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Library.Services.Data.Admin
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<List<Role>> GetRoleByUserIdAsync(int userId, int branchId);
        Task<List<Role>> GetRoleByBranchIdAsync(int branchId);
    }
}
