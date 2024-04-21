using HotelManagementSystem.Contracts.APIModels.Admin;
using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.Contracts.Generic.Response;
using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library.Services.Data.Admin;

namespace HotelManagementSystem.Admin.Blanket.User
{
    public class UserBlanket
    {
        private readonly UserService _userService;
        private readonly HotelBranchService _branchService;
        private readonly IAdminUnitOfWork _adminUnitOfWork;

        public UserBlanket(HotelBranchService hotelBranchService, UserService userService, IAdminUnitOfWork adminUnitOfWork) 
        {
            _userService = userService;
            _branchService = hotelBranchService;
            _adminUnitOfWork = adminUnitOfWork;
        }
        public async Task<HTTPResponse> Login(LoginModel loginModel)
        {
            Object data = default(Object);
            string message = string.Empty;
            int retVal = -40;
            try
            {
                
                //Get Current branch Details
                var branch = await _branchService.GetCurrentInstance();

                Contracts.Entities.Admin.User user = await _userService.ValidateUserAsync(branch.Id, loginModel.UserName, loginModel.Password);  
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

        public async Task<HTTPResponse> AddUser(UserModel userModel, string userGuid)
        {
            Object data = default(Object);
            string message = string.Empty;
            int retVal = -40;
            try
            {

                //Get Current branch Details
                var branch = await _branchService.GetCurrentInstance();

                Contracts.Entities.Admin.User user = new Contracts.Entities.Admin.User()
                {
                    AddressLine1 = userModel.AddressLine1,
                    AddressLine2 = userModel.AddressLine2,
                    City = userModel.City,
                    Country = userModel.Country,
                    DateOfBirth = userModel.DateOfBirth,
                    Email = userModel.Email,
                    FirstName = userModel.FirstName,
                    Gender = userModel.Gender,
                    Guid = Guid.NewGuid(),
                    HotelBranchId = branch.Id,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = userGuid,
                    LastName = userModel.LastName,
                    MiddleName = userModel.MiddleName,
                    Password = userModel.Password,
                    Phone = userModel.Phone,
                    UserName = userModel.UserName,
                    State = userModel.State,
                    Zipcode = userModel.Zipcode
                };

                user.UserId = await _adminUnitOfWork.UserRepository.AddUser(user);

                if (user.UserId == 0)
                    throw new Exception("User was not added");

                //Assign Role
                if(userModel.RoleId != 0)
                {
                    RoleAssignment roleAssignment = new RoleAssignment()
                    {
                        RoleId = userModel.RoleId,
                        UserId = user.UserId,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = userGuid,
                        HotelBranchId = branch.Id
                    };

                    retVal = await _adminUnitOfWork.RoleRepository.AssignRoleToAUser(roleAssignment);

                    data = retVal;
                }
                
            }
            catch (Exception ex)
            {
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, ex.Message);
            }

            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        }
    }
}
