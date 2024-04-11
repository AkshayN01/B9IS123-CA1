using HotelManagementSystem.Contracts.Permissions;
using HotelManagementSystem.Library.Services.Data.FrontDesk;
using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.FrontDesk.API.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    [Authorize]
    public class RoomController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ILogger<RoomController> _logger;
        private readonly Blanket.Room.RoomBlanket _RoomBlanket;

        public RoomController(ILogger<RoomController> logger, IFrontDeskUnitOfWork frontDeskUnitOfWork, ManagementService managementService, UserService userService)
        {
            _logger = logger;
            _userService = userService;
            _RoomBlanket = new Blanket.Room.RoomBlanket(frontDeskUnitOfWork);
        }

        [HttpGet]
        [Route("/userId/{userGuid}/rooms")]
        public async Task<IActionResult> GetAllRooms(string userGuid, int roomTypeId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<string> requiredPermission = new List<string>() { AdministratorPermissions.ViewRole };

            bool hasPermission = await _userService.HasPermissions(userGuid, requiredPermission);
            if (!hasPermission)
                return Unauthorized();

            try
            {
                var httpResponse = await _RoomBlanket.GetAllRoom(roomTypeId);
                return Ok(httpResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("/userId/{userGuid}/roomTypes")]
        public async Task<IActionResult> GetAllRoomTypes(string userGuid)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<string> requiredPermission = new List<string>() { AdministratorPermissions.ViewRole };

            bool hasPermission = await _userService.HasPermissions(userGuid, requiredPermission);
            if (!hasPermission)
                return Unauthorized();

            try
            {
                var httpResponse = await _RoomBlanket.GetAllRoomTypes();
                return Ok(httpResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
