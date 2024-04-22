using HotelManagementSystem.Admin.Blanket.Permission;
using HotelManagementSystem.Contracts.APIModels.Admin;
using HotelManagementSystem.Contracts.Permissions;
using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library.Services.Data.Admin;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Admin.API.Controllers
{
    [ApiController]

    public class PermissionController : ControllerBase
    {
        private readonly PermissionBlanket permissionBlanket;
        private readonly UserService _userService;
        public PermissionController(HotelBranchService hotelBranchService, IAdminUnitOfWork adminUnitOfWork, UserService userService) 
        {
            _userService = userService;
            permissionBlanket = new PermissionBlanket(hotelBranchService, adminUnitOfWork);
        }

        [HttpPost]
        [Route("/api/userGuid/{userGuid}/permissions")]
        public async Task<IActionResult> AddPermission(string userGuid, [FromBody] List<PermissionModel> permissions)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<string> requiredPermission = new List<string>() { AdministratorPermissions.AddPermission };

            bool hasPermission = await _userService.HasPermissions(userGuid, requiredPermission);
            if (!hasPermission || userGuid == "System")
                return Unauthorized();

            try
            {
                var httpResponse = await permissionBlanket.AddPermission(permissions);
                return Ok(httpResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
    }
}