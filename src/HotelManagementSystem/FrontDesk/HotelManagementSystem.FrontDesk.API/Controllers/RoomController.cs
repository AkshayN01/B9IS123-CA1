using HotelManagementSystem.Contracts.Permissions;
using HotelManagementSystem.Library.Services.Data.FrontDesk;
using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelManagementSystem.FrontDesk.API.Controllers
{
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ILogger<RoomController> _logger;
        private readonly Blanket.Room.RoomBlanket _RoomBlanket;

        public RoomController(ILogger<RoomController> logger, IFrontDeskUnitOfWork frontDeskUnitOfWork, ManagementService managementService, UserService userService, HotelBranchService hotelBranchService)
        {
            _logger = logger;
            _userService = userService;
            _RoomBlanket = new Blanket.Room.RoomBlanket(frontDeskUnitOfWork, hotelBranchService);
        }

        [HttpGet]
        [Route("/api/userGuid/{userGuid}/rooms")]
        public async Task<IActionResult> GetAllRooms(string userGuid, int roomTypeId, int statusId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<string> requiredPermission = new List<string>() { FrontDeskPermissions.ViewRoom };

            bool hasPermission = await _userService.HasPermissions(userGuid, requiredPermission);
            if (!hasPermission || userGuid == "System")
                return Unauthorized();

            try
            {
                var httpResponse = await _RoomBlanket.GetAllRoom(roomTypeId, statusId);
                return Ok(httpResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("/api/userGuid/{userGuid}/roomTypes")]
        public async Task<IActionResult> GetAllRoomTypes(string userGuid)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<string> requiredPermission = new List<string>() { FrontDeskPermissions.ViewRoom };

            bool hasPermission = await _userService.HasPermissions(userGuid, requiredPermission);
            if (!hasPermission || userGuid == "System")
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