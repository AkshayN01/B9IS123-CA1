using HotelManagementSystem.Contracts.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Library.Services.Data.Admin
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Task<List<Permission>> GetRolePermissionsAsync(int roleId, int branchId);

        Task<int> AddPermissions(List<Permission> permissions);
    }
}