using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Library.Services.Data.Admin
{
    public interface IAdminUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IHotelBranchRepository HotelBranchRepository { get; }
        IRoleRepository RoleRepository { get; }
        IPermissionRepository PermissionRepository { get; }
    }
}
