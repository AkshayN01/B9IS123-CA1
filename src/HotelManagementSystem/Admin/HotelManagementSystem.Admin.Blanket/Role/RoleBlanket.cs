using HotelManagementSystem.Contracts.APIModels.Admin;
using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.Contracts.Generic.Response;
using HotelManagementSystem.Library;
using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library.Services.Data.Admin;
using System.Security;

namespace HotelManagementSystem.Admin.Blanket.Role
{
    public class RoleBlanket
    {
        private readonly UserService _userService;
        private readonly ManagementService _managementService;
        private readonly HotelBranchService _branchService;
        private readonly IAdminUnitOfWork _adminUnitOfWork;
        public RoleBlanket(ManagementService managementService, UserService userService, HotelBranchService hotelBranchService, IAdminUnitOfWork adminUnitOfWork)
        {
            _branchService = hotelBranchService;
            _managementService = managementService;
            _userService = userService;
            _adminUnitOfWork = adminUnitOfWork;
        }

        public async Task<HTTPResponse> AddRole(string userGuid, RoleModel roleModel)
        {
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;

            try
            {
                //Get Current branch Details
                var branch = await _branchService.GetCurrentInstance();

                Contracts.Entities.Admin.Role role = new Contracts.Entities.Admin.Role()
                {
                    Name = roleModel.Name,
                    ShortName = roleModel.ShortName,
                    Description = roleModel.Description,
                    CreatedBy = userGuid,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false,
                    HotelBranchId = branch.Id,
                };

                role.RoleId = await _adminUnitOfWork.RoleRepository.AddRoleAsync(role);

                //Assign Permissions to the role
                if(roleModel.PermissionIds.Any())
                {
                    List<PermissionAssignment> assignments = new List<PermissionAssignment>();
                    foreach(var permision in roleModel.PermissionIds)
                    {
                        PermissionAssignment assignment = new PermissionAssignment()
                        {
                            CreatedAt = DateTime.UtcNow,
                            CreatedBy = userGuid,
                            IsDeleted = false,
                            HotelBranchId = branch.Id,
                            RoleId = role.RoleId,
                            PermissionId = permision
                        };
                        assignments.Add(assignment);
                    }
                    retVal = await _adminUnitOfWork.PermissionAssignmentRepository.AddPermissionAssignmentAsync(assignments);
                    if (retVal == 0)
                        throw new Exception("Failed while assigning permissions");
                }
            }
            catch (Exception ex)
            {
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, ex.Message);
            }

            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        }
        public async Task<HTTPResponse> AssignPermissionToRole(string userGuid, PermissionAssignModel roleModel)
        {
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;

            try
            {
                //Get Current branch Details
                var branch = await _branchService.GetCurrentInstance();

                if (roleModel.RoleId == 0)
                    throw new Exception("Invalid role id");

                if (!roleModel.PermissionIds.Any())
                    throw new Exception("No permissions to assign");

                Contracts.Entities.Admin.Role role = await _adminUnitOfWork.RoleRepository.GetAsync(roleModel.RoleId);

                if (role == null)
                    throw new Exception("No such roles found");

                //check whether all the permissions are present
                List<Contracts.Entities.Admin.Permission> permissions = new List<Contracts.Entities.Admin.Permission>();
                foreach(int id in roleModel.PermissionIds)
                {
                    var permission = await _adminUnitOfWork.PermissionRepository.GetAsync(id);
                    if(permission != null)
                    {
                        permissions.Add(permission);
                    }
                }

                //check if permissions were already applied to the role
                var appliedPermissions = await _userService.GetRolePermissionsAsync(role.RoleId, branch.Id);

                if(appliedPermissions != null)
                {
                    permissions.RemoveAll(p => appliedPermissions.Select(x => x.PermissionId).ToList().Contains(p.PermissionId));
                    List<PermissionAssignment> assignments = new List<PermissionAssignment>();
                    if (permissions.Any())
                    {
                        foreach (var permission in permissions)
                        {
                            PermissionAssignment assignment = new PermissionAssignment()
                            {
                                CreatedAt = DateTime.UtcNow,
                                CreatedBy = userGuid,
                                IsDeleted = false,
                                HotelBranchId = branch.Id,
                                RoleId = role.RoleId,
                                PermissionId = permission.PermissionId,
                            };
                            assignments.Add(assignment);
                        }
                        retVal = await _adminUnitOfWork.PermissionAssignmentRepository.AddPermissionAssignmentAsync(assignments);
                        _adminUnitOfWork.Commit();
                    }
                    else
                    {
                        retVal = 1;
                        message = "No Permissions to assign.";
                    }
                    if (retVal == 0)
                        throw new Exception("Failed while assigning permissions");

                    data = retVal;
                }
            }
            catch (Exception ex)
            {
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, ex.Message);
            }

            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        }

        public async Task<HTTPResponse> GetAllRoles(int branchId, string userGuid)
        {
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;

            try
            {
                List<Contracts.Entities.Admin.Role> roles = await _managementService.GetRolesAsync(branchId);

                data = roles;
            }
            catch (Exception ex)
            {
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, ex.Message);
            }

            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        } 
    }
}