﻿using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.Library.Services.Data.Admin;
using IdentityModel;
using Newtonsoft.Json;
using System.Data;
using System.Security.Claims;

namespace HotelManagementSystem.Library.Services
{
    public class UserService
    {
        private readonly IAdminUnitOfWork _unitOfWork;
        private readonly HotelBranchService _branchService;

        public UserService(IAdminUnitOfWork unitOfWork, HotelBranchService branchService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _branchService = branchService ?? throw new ArgumentNullException(nameof(branchService));
        }

        public async Task<bool> ValidateCredentialsAsync(int branchId, string username, string password)
        {
            bool IsValid = false;

            try
            {
                User user = await GetUserByUsernameAsync(branchId, username);
                if(user != null)
                {
                    IsValid = password == user.Password;
                }
            }
            catch (Exception ex) { }

            return IsValid;
        }

        public async Task<User> GetUserByGuidAsync(string guid)
        {
            var user = await _unitOfWork.UserRepository.GetUserByGuid(new Guid(guid));

            return user;
        }

        public async Task<User> GetUserByUsernameAsync(int branchId, string username)
        {
            User user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username, branchId);

            return user;
        }
        public async Task<Claim[]> GetUserClaimsAsync(User user, bool includePermissions = false)
        {
            List<Role> userRoles = await GetUserRolesAsync(user.UserId, user.HotelBranchId);
            var roles = userRoles?.Select(x => new
            {
                RoleName = x.Name,
                RoleShortName = x.ShortName
            }).ToList();

            List<String> permissions = new List<String>();

            if (roles != null && roles.Count > 0)
            {
                foreach (Role role in userRoles)
                {
                    var permissionByRole = await GetRolePermissionsAsync(role.RoleId, role.HotelBranchId);
                    if (permissionByRole.Any())
                    {
                        permissions.AddRange(permissionByRole?.Select(x => x.Name).ToList());
                    }
                }
            }
            var claims = new List<Claim>
            {

            };

            if (includePermissions)
            {
                claims.AddRange(new List<Claim>
                {
                    new Claim("userGuid", user.Guid.ToString() ?? ""),
                    new Claim("branchId", user.HotelBranchId.ToString() ?? ""),
                    new Claim(JwtClaimTypes.Name, (!string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName)) ? (user.FirstName + " " + user.LastName) : ""),
                    new Claim(JwtClaimTypes.Email, user.Email  ?? ""),
                    new Claim("userName", user.UserName  ?? ""),
                    new Claim(JwtClaimTypes.Role, JsonConvert.SerializeObject(roles)),
                    new Claim("permissions", JsonConvert.SerializeObject(permissions))
                });
            }
            return claims.ToArray();
        }

        public async Task<List<string>> GetUserPermissions(int userId, int branchId)
        {
            List<string> permissions = new List<string>();

            List<Role> userRoles = await GetUserRolesAsync(userId, branchId);

            if (userRoles != null && userRoles.Count > 0)
            {
                foreach (Role role in userRoles)
                {
                    var permissionByRole = await GetRolePermissionsAsync(role.RoleId, role.HotelBranchId);
                    if (permissionByRole.Any())
                    {
                        permissions.AddRange(permissionByRole?.Select(x => x.Name).ToList() ?? []);
                    }
                }
            }

            return permissions;
        }
        public async Task<List<Role>> GetUserRolesAsync(int userId, int instanceId)
        {
            var roles = await _unitOfWork.RoleRepository.GetRoleByUserIdAsync(userId, instanceId);

            return roles;
        }
        public async Task<List<Permission>> GetRolePermissionsAsync(int roleId, int instanceId)
        {
            var permissions = await _unitOfWork.PermissionRepository.GetRolePermissionsAsync(roleId, instanceId);

            return permissions;
        }
        
        public async Task<bool> HasPermissions(string userGuid, List<string> permissions)
        {
            bool hasPermission = false;

            try
            {
                var currentBranch = await _branchService.GetCurrentInstance();
                if (currentBranch == null)
                    throw new Exception("No current branch details found");

                var user = await GetUserByGuidAsync(userGuid);
                List<string> userPermissions = await GetUserPermissions(user.UserId, currentBranch.Id);
                if (userPermissions.Any())
                {
                    foreach (var p in permissions)
                    {
                        if (!userPermissions.Contains(p)) { return false; }
                        else { hasPermission = true; }
                    }
                }
            }
            catch(Exception ex) { }

            return hasPermission;
        }
        public async Task<User> ValidateUserAsync(int branchId, string username, string password)
        {
            User user = null;

            try
            {
                user = await GetUserByUsernameAsync(branchId, username);
                if (user != null)
                {
                    bool IsValid = password == user.Password;
                    if(IsValid)
                    {
                        return user;
                    }
                }
            }
            catch (Exception ex) { }

            return user;
        }

        public async Task<(List<string>, List<string>)> GetUserRolesAndPermissionsAsync(int userId, int branchId)
        {
            List<Role> userRoles = await GetUserRolesAsync(userId, branchId);
            var roles = userRoles?.Select(x => x.Name).ToList();

            List<String> permissions = new List<String>();

            if (roles != null && roles.Count > 0)
            {
                foreach (Role role in userRoles)
                {
                    var permissionByRole = await GetRolePermissionsAsync(role.RoleId, role.HotelBranchId);
                    if (permissionByRole.Any())
                    {
                        permissions.AddRange(permissionByRole?.Select(x => x.Name).ToList());
                    }
                }
            }
            return (roles, permissions);
        }
    }
}
