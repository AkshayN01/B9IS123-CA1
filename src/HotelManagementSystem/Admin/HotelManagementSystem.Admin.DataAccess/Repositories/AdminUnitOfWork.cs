using HotelManagementSystem.Admin.DataAccess.Repositories.Admin;
using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.DataAccess.Repositories.Admin;
using HotelManagementSystem.Library.Services.Data;
using HotelManagementSystem.Library.Services.Data.Admin;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.DataAccess.Repositories
{
    public class AdminUnitOfWork : IAdminUnitOfWork
    {
        private IUserRepository _userRepository;
        private IHotelBranchRepository _hotelBranchRepository;
        private IRoleRepository _roleRepository;
        private IPermissionRepository _permissionRepository;
        private IPermissionAssignmentRepository _permissionAssginmentRepository;
        private IRoleAssignmentRepository _roleAssignmentRepository;

        private readonly AdminDbContext _context;

        public AdminUnitOfWork(AdminDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Rollback changes if needed
        }
        public IUserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_context); }
        }

        public IHotelBranchRepository HotelBranchRepository
        {
            get { return _hotelBranchRepository ??= new HotelBranchRepository(_context); }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ??= new RoleRepository(_context); }
        }

        public IPermissionRepository PermissionRepository
        {
            get { return _permissionRepository ??= new PermissionRepository(_context); }
        }

        public IPermissionAssignmentRepository PermissionAssignmentRepository
        {
            get { return _permissionAssginmentRepository ??= new PermissionAssignmentRepository(_context); }
        }

        public IRoleAssignmentRepository RoleAssignmentRepository
        {
            get { return _roleAssignmentRepository ??= new RoleAssignmentRepository(_context); } 
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}