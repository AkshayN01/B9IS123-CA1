using HotelManagementSystem.Contracts.APIModels.Admin;
using HotelManagementSystem.Contracts.Generic.Response;
using HotelManagementSystem.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Admin.Blanket.User
{
    public class UserBlanket
    {
        private readonly UserService _userService;
        public UserBlanket(UserService userService) 
        {
            _userService = userService;
        }
        public async Task<HTTPResponse> Login(LoginModel loginModel)
        {
            Object data = default(Object);
            string message = string.Empty;
            int retVal = -40;
            try
            {
                Contracts.Entities.Admin.User user = await _userService.ValidateUserAsync(1, loginModel.UserName, loginModel.Password);  
                if (user != null)
                {
                    LoginResponse response = new LoginResponse() { UserGuid = user.Guid.ToString() };
                    (response.Roles, response.Permissions) = await _userService.GetUserRolesAndPermissionsAsync(user.UserId, user.HotelBranchId);
                    data = response;
                }
                else
                {
                    throw new Exception("user not found. Use valid credentials");
                }
            }
            catch (Exception ex)
            {
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, ex.Message);
            }
            retVal = 1;
            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        }
    }
}
