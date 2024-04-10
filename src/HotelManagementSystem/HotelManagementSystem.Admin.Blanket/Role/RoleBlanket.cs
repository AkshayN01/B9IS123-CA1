using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.Contracts.Generic.Response;
using HotelManagementSystem.Contracts.Permissions;
using HotelManagementSystem.Library;
using HotelManagementSystem.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Admin.Blanket.Role
{
    public class RoleBlanket
    {
        private readonly UserService _userService;
        private readonly ManagementService _managementService;
        public RoleBlanket(ManagementService managementService, UserService userService)
        {
            _managementService = managementService;
            _userService = userService;
        }

        public async Task<HTTPResponse> GetAllRoles(int branchId, int userid)
        {
            List<string> requiredPermission = new List<string>() { AdministratorPermissions.ViewRole };
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;

            try
            {
                bool hasPermission = await _userService.HasPermissions(userid, branchId, requiredPermission);
                if (!hasPermission)
                    throw new Exception("User doesn't have permissions");

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
