using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library;
using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Contracts.APIModels.Admin;
using HotelManagementSystem.Admin.Blanket.Role;
using HotelManagementSystem.Contracts.APIModels.FontDesk;
using HotelManagementSystem.Contracts.Permissions;
using HotelManagementSystem.Library.Services.Data.Admin;

namespace HotelManagementSystem.Admin.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ILogger<RoleController> _logger;
        private readonly Blanket.User.UserBlanket _userBlanket;

        public UserController(ILogger<RoleController> logger, ManagementService managementService, HotelBranchService hotelBranchService, UserService userService, IAdminUnitOfWork adminUnitOfWork)
        {
            _logger = logger;
            _userService = userService;
            _userBlanket = new Blanket.User.UserBlanket(hotelBranchService, userService, adminUnitOfWork);
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var httpResponse = await _userBlanket.Login(loginModel);
                return Ok(httpResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("/api/userGuid/{userGuid}/add-user")]
        public async Task<IActionResult> AddUser(string userGuid, [FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<string> requiredPermission = new List<string>() { AdministratorPermissions.AddUser };

            bool hasPermission = await _userService.HasPermissions(userGuid, requiredPermission);
            if (!hasPermission)
                return Unauthorized();

            try
            {
                var httpResponse = await _userBlanket.AddUser(userModel, userGuid);
                return Ok(httpResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}