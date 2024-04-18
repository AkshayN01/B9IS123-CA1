using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library;
using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Contracts.APIModels.Admin;

namespace HotelManagementSystem.Admin.API.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ILogger<RoleController> _logger;
        private readonly Blanket.User.UserBlanket _userBlanket;

        public LoginController(ILogger<RoleController> logger, ManagementService managementService, UserService userService)
        {
            _logger = logger;
            _userService = userService;
            _userBlanket = new Blanket.User.UserBlanket(userService);
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
    }
}
