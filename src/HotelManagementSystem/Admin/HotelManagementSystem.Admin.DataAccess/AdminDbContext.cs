using HotelManagementSystem.Admin.DataAccess.Data;
using HotelManagementSystem.Contracts.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DataAccess
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<HotelBranch> Branches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RoleAssignment> RoleAssignments { get; set; }
        public DbSet<PermissionAssignment> PermissionAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelBranch>().HasData(AdminData.GetHotelBranches());
            modelBuilder.Entity<Role>().HasData(AdminData.GetAllRoles());
            modelBuilder.Entity<Permission>().HasData(AdminData.GetPermissions());
            modelBuilder.Entity<PermissionAssignment>().HasData(AdminData.GetPermissionAssignments());
            modelBuilder.Entity<User>().HasData(AdminData.GetAllUsers());
            modelBuilder.Entity<RoleAssignment>().HasData(AdminData.GetAllRoleAssignments());
        }
    }
}
