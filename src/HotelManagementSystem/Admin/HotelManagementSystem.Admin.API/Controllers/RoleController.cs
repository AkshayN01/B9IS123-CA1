using HotelManagementSystem.Contracts.Generic.Response;
using HotelManagementSystem.Library;
using HotelManagementSystem.Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Admin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly Blanket.Role.RoleBlanket _RoleBlanket;

        public RoleController(ILogger<RoleController> logger, ManagementService managementService, UserService userService)
        {
            _logger = logger;
            _RoleBlanket = new Blanket.Role.RoleBlanket(managementService, userService);
        }

        [HttpGet]
        [Route("/userId/{userId}/getAllRoles")]
        public async Task<HTTPResponse> GetAllRoles(int userId, int branchId)
        {
            if(ModelState.IsValid)
            {
                return await _RoleBlanket.GetAllRoles(branchId, userId);
            }
            else
            {
                return new HTTPResponse();
            }
        }
    }
}
