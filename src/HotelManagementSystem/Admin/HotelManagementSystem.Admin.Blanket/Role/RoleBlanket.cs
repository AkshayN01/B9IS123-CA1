using HotelManagementSystem.Contracts.APIModels.Admin;
using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.Contracts.Generic.Response;
using HotelManagementSystem.Library;
using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library.Services.Data.Admin;

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