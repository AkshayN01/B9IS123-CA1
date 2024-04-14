using HotelManagementSystem.Contracts.Entities.Admin;

namespace HotelManagementSystem.Admin.DataAccess.Data
{
    public static class AdminData
    {
        public static List<HotelBranch> GetHotelBranches()
        {
            return new List<HotelBranch>()
            {
                new HotelBranch() { Id = 1, Name = "The Wangchuks Hotel, Dublin", Address="Dublin 01", City="Dublin", IsActive = true, IsCurrent = 1},
                new HotelBranch() { Id = 2, Name = "The Wangchuks Hotel, Cork", Address="Cork 01", City="Cork", IsActive = true, IsCurrent = 0}
            };
        }

        public static List<Permission> GetPermissions()
        {
            return new List<Permission>()
            {
                //**ADMIN**
                //Roles
                new Permission(){ PermissionId = 1, Name="admin:role:add", CreatedAt = DateTime.UtcNow, Description = "Permission to add a new role to a branch", HotelBranchId = 1},
                new Permission(){ PermissionId = 2, Name="admin:role:view", CreatedAt = DateTime.UtcNow, Description = "Permission to view a role", HotelBranchId = 1},
                new Permission(){ PermissionId = 3, Name="admin:role:edit", CreatedAt = DateTime.UtcNow, Description = "Permission to edit a role", HotelBranchId = 1},
                new Permission(){ PermissionId = 4, Name="admin:role:delete", CreatedAt = DateTime.UtcNow, Description = "Permission to delete a role", HotelBranchId = 1},

                //Permissions
                new Permission(){ PermissionId = 5, Name="admin:permission:add", CreatedAt = DateTime.UtcNow, Description = "Permission to add a permission", HotelBranchId = 1},
                new Permission(){ PermissionId = 6, Name="admin:permission:view", CreatedAt = DateTime.UtcNow, Description = "Permission to view a permission", HotelBranchId = 1},
                new Permission(){ PermissionId = 7, Name="admin:permission:edit", CreatedAt = DateTime.UtcNow, Description = "Permission to edit a permission", HotelBranchId = 1},
                new Permission(){ PermissionId = 8, Name="admin:permission:delete", CreatedAt = DateTime.UtcNow, Description = "Permission to delete a permission", HotelBranchId = 1},

                //Users
                new Permission(){ PermissionId = 9, Name="admin:user:add", CreatedAt = DateTime.UtcNow, Description = "Permission to add a user", HotelBranchId = 1},
                new Permission(){ PermissionId = 10, Name="admin:user:view", CreatedAt = DateTime.UtcNow, Description = "Permission to view a user", HotelBranchId = 1},
                new Permission(){ PermissionId = 11, Name="admin:user:edit", CreatedAt = DateTime.UtcNow, Description = "Permission to add a user", HotelBranchId = 1},
                new Permission(){ PermissionId = 12, Name="admin:user:delete", CreatedAt = DateTime.UtcNow, Description = "Permission to add a user", HotelBranchId = 1},

                //Visitors
                new Permission(){ PermissionId = 13, Name="admin:visitor:add", CreatedAt = DateTime.UtcNow, Description = "Permission to add a visitor", HotelBranchId = 1},
                new Permission(){ PermissionId = 14, Name="admin:visitor:view", CreatedAt = DateTime.UtcNow, Description = "Permission to view a visitor", HotelBranchId = 1},
                new Permission(){ PermissionId = 15, Name="admin:visitor:edit", CreatedAt = DateTime.UtcNow, Description = "Permission to edit a visitor", HotelBranchId = 1},
                new Permission(){ PermissionId = 16, Name="admin:visitor:delete", CreatedAt = DateTime.UtcNow, Description = "Permission to delete a visitor", HotelBranchId = 1},

                //Super Admin
                new Permission(){ PermissionId = 17, Name="superadmin", CreatedAt = DateTime.UtcNow, Description = "All Permissions", HotelBranchId = 1},

                //**FrontDesk**
                //Booking
                new Permission(){PermissionId = 18, Name = "frontdesk:booking:add", Description = "Permission to add a visitor booking", HotelBranchId = 1, CreatedAt = DateTime.UtcNow},
                new Permission(){PermissionId = 19, Name = "frontdesk:booking:view", Description = "Permission to view a visitor booking", HotelBranchId = 1, CreatedAt = DateTime.UtcNow},
                new Permission(){PermissionId = 20, Name = "frontdesk:booking:edit", Description = "Permission to edit a visitor booking", HotelBranchId = 1, CreatedAt = DateTime.UtcNow},
                new Permission(){PermissionId = 21, Name = "frontdesk:booking:delete", Description = "Permission to delete a visitor booking", HotelBranchId = 1, CreatedAt = DateTime.UtcNow},
                new Permission(){PermissionId = 22, Name = "frontdesk:booking:approve", Description = "Permission to approve a visitor booking", HotelBranchId = 1, CreatedAt = DateTime.UtcNow},
                new Permission(){PermissionId = 23, Name = "frontdesk:booking:decline", Description = "Permission to decline a visitor booking", HotelBranchId = 1, CreatedAt = DateTime.UtcNow},
                new Permission(){PermissionId = 24, Name = "frontdesk:visior:add", Description = "Permission to add a visitor", HotelBranchId = 1, CreatedAt = DateTime.UtcNow},
                new Permission(){PermissionId = 25, Name = "frontdesk:visior:view", Description = "Permission to view a visitor", HotelBranchId = 1, CreatedAt = DateTime.UtcNow},
                new Permission(){PermissionId = 26, Name = "frontdesk:visior:edit", Description = "Permission to edit a visitor", HotelBranchId = 1, CreatedAt = DateTime.UtcNow},
                new Permission(){PermissionId = 27, Name = "frontdesk:visior:delete", Description = "Permission to delete a visitor", HotelBranchId = 1, CreatedAt = DateTime.UtcNow},

            };
        }

        public static List<Role> GetAllRoles()
        {
            return new List<Role>()
            {
                new Role(){ RoleId = 1, Name= "Super Admin", ShortName="SuperAdmin", Description = "Has all the Permissions", HotelBranchId = 1, IsDeleted = false, CreatedAt = DateTime.UtcNow, CreatedBy = "System" },
                new Role(){ RoleId = 2, Name= "Admin", ShortName="Admin", Description = "Has all the root permissions", HotelBranchId = 1, IsDeleted = false, CreatedAt = DateTime.UtcNow, CreatedBy = "System" },
                new Role(){ RoleId = 3, Name= "Front Desk Manager", ShortName="FDManager", Description = "Manager of the Front Desk Department", HotelBranchId = 1, IsDeleted = false, CreatedAt = DateTime.UtcNow, CreatedBy = "System" },
                new Role(){ RoleId = 4, Name= "Front Desk Assistant", ShortName="FDAssistant", Description = "Assistant staff of the Front Desk Department", HotelBranchId = 1, IsDeleted = false, CreatedAt = DateTime.UtcNow, CreatedBy = "System" },
            };
        }

        public static List<User> GetAllUsers()
        {
            return new List<User> { 
                new User(){ UserId = 1, UserName = "akshayn", FirstName = "Akshay", MiddleName="Mohanan", LastName="Nambly", Phone="12345", Email="namblyakshay@gmail.com", HotelBranchId=1, IsDeleted=false,Guid=Guid.NewGuid(), IsActive = true, Password="Test1234", IsEmailVerified = true, CreatedAt = DateTime.UtcNow, CreatedBy = "System"},
                new User(){ UserId = 2, UserName = "chaitrau", FirstName = "Chaitra", MiddleName="", LastName="Umesh", Phone="123456", Email="chaitraumesh.96@gmail.com", HotelBranchId=1, IsDeleted=false,Guid=Guid.NewGuid(), IsActive = true, Password="Test1234", IsEmailVerified = true, CreatedAt = DateTime.UtcNow, CreatedBy = "System"},
                new User(){ UserId = 3, UserName = "jittyt", FirstName = "Jitty", MiddleName="", LastName="Thomas", Phone="123457", Email="jittythomas774@gmail.com", HotelBranchId=1, IsDeleted=false,Guid=Guid.NewGuid(), IsActive = true, Password="Test1234", IsEmailVerified = true, CreatedAt = DateTime.UtcNow, CreatedBy = "System"},
                new User(){ UserId = 4, UserName = "robinss", FirstName = "Robins", MiddleName="", LastName="Sojan", Phone="123458", Email="robinssojan26@gmail.com", HotelBranchId=1, IsDeleted=false,Guid=Guid.NewGuid(), IsActive = true, Password="Test1234", IsEmailVerified = true, CreatedAt = DateTime.UtcNow, CreatedBy = "System"},
                new User(){ UserId = 5, UserName = "superAdmin", FirstName = "Super", MiddleName="", LastName="Admin", Phone="123459", Email="test.admin@gmail.com", HotelBranchId=1, IsDeleted=false,Guid=Guid.NewGuid(), IsActive = true, Password="Test1234", IsEmailVerified = true, CreatedAt = DateTime.UtcNow, CreatedBy = "System"},
            };
        }

        public static List<RoleAssignment> GetAllRoleAssignments()
        {
            return new List<RoleAssignment>
            {
                new RoleAssignment{ RoleAssignmentId = 1, RoleId = 1, HotelBranchId = 1, UserId = 5, CreatedAt = DateTime.UtcNow, CreatedBy = "System", IsDeleted = false},
                new RoleAssignment{ RoleAssignmentId = 2, RoleId = 3, HotelBranchId = 1, UserId = 1, CreatedAt = DateTime.UtcNow, CreatedBy = "System", IsDeleted = false},
                new RoleAssignment{ RoleAssignmentId = 3, RoleId = 4, HotelBranchId = 1, UserId = 2, CreatedAt = DateTime.UtcNow, CreatedBy = "System", IsDeleted = false},
                new RoleAssignment{ RoleAssignmentId = 4, RoleId = 4, HotelBranchId = 1, UserId = 3, CreatedAt = DateTime.UtcNow, CreatedBy = "System", IsDeleted = false},
                new RoleAssignment{ RoleAssignmentId = 5, RoleId = 3, HotelBranchId = 1, UserId = 4, CreatedAt = DateTime.UtcNow, CreatedBy = "System", IsDeleted = false},
            };
        }

        public static List<PermissionAssignment> GetPermissionAssignments()
        {
            return new List<PermissionAssignment>()
            {
                //Super Admin
                new PermissionAssignment(){PermissionAssignmentId = 1, HotelBranchId = 1, PermissionId = 17, RoleId = 1, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},

                //Admin
                new PermissionAssignment(){PermissionAssignmentId = 2, HotelBranchId = 1, PermissionId = 1, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 3, HotelBranchId = 1, PermissionId = 2, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 4, HotelBranchId = 1, PermissionId = 3, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 5, HotelBranchId = 1, PermissionId = 4, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 6, HotelBranchId = 1, PermissionId = 5, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 7, HotelBranchId = 1, PermissionId = 6, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 8, HotelBranchId = 1, PermissionId = 7, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 9, HotelBranchId = 1, PermissionId = 8, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 10, HotelBranchId = 1, PermissionId = 8, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 11, HotelBranchId = 1, PermissionId = 9, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 12, HotelBranchId = 1, PermissionId = 10, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 13, HotelBranchId = 1, PermissionId = 11, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 14, HotelBranchId = 1, PermissionId = 12, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 15, HotelBranchId = 1, PermissionId = 13, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 16, HotelBranchId = 1, PermissionId = 14, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 17, HotelBranchId = 1, PermissionId = 15, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 18, HotelBranchId = 1, PermissionId = 16, RoleId = 2, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},

                //Manager
                new PermissionAssignment(){PermissionAssignmentId = 32, HotelBranchId = 1, PermissionId = 18, RoleId = 3, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 19, HotelBranchId = 1, PermissionId = 19, RoleId = 3, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 20, HotelBranchId = 1, PermissionId = 20, RoleId = 3, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 21, HotelBranchId = 1, PermissionId = 21, RoleId = 3, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 22, HotelBranchId = 1, PermissionId = 22, RoleId = 3, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 23, HotelBranchId = 1, PermissionId = 23, RoleId = 3, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 24, HotelBranchId = 1, PermissionId = 24, RoleId = 3, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 25, HotelBranchId = 1, PermissionId = 25, RoleId = 3, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},

                //Assistant
                new PermissionAssignment(){PermissionAssignmentId = 26, HotelBranchId = 1, PermissionId = 18, RoleId = 4, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 27, HotelBranchId = 1, PermissionId = 19, RoleId = 4, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 28, HotelBranchId = 1, PermissionId = 20, RoleId = 4, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 29, HotelBranchId = 1, PermissionId = 22, RoleId = 4, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 30, HotelBranchId = 1, PermissionId = 24, RoleId = 4, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
                new PermissionAssignment(){PermissionAssignmentId = 31, HotelBranchId = 1, PermissionId = 25, RoleId = 4, CreatedAt= DateTime.UtcNow, CreatedBy= "System", IsDeleted = false},
            };
        }
    }
}
