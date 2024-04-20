using HotelManagementSystem.Contracts.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Library.Services.Data.Admin
{
    public interface IPermissionAssignmentRepository
    {
        Task<int> AddPermissionAssignmentAsync(List<PermissionAssignment> permissionAssignments);
    }
}