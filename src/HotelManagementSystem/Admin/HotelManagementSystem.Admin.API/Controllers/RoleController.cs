using HotelManagementSystem.Contracts.Permissions;
using HotelManagementSystem.Library;
using HotelManagementSystem.Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Admin.API.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ILogger<RoleController> _logger;
        private readonly Blanket.Role.RoleBlanket _RoleBlanket;

        public RoleController(ILogger<RoleController> logger, ManagementService managementService, UserService userService)
        {
            _logger = logger;
            _userService = userService;
            _RoleBlanket = new Blanket.Role.RoleBlanket(managementService, userService);
        }

        [HttpGet]
        [Route("/userId/{userGuid}/getAllRoles")]
        public async Task<IActionResult> GetAllRoles(string userGuid, int branchId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<string> requiredPermission = new List<string>() { AdministratorPermissions.ViewRole };

            bool hasPermission = await _userService.HasPermissions(userGuid, requiredPermission);
            if (!hasPermission)
                return Unauthorized();

            try
            {
                var httpResponse = await _RoleBlanket.GetAllRoles(branchId, userGuid);
                return Ok(httpResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
