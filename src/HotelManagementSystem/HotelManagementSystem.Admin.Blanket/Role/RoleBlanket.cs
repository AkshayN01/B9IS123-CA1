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
