using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Contracts.Permissions;
using HotelManagementSystem.Library.Services.Data.FrontDesk;
using HotelManagementSystem.Contracts.APIModels.FontDesk;
using System.Security.Claims;

namespace HotelManagementSystem.FrontDesk.API.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ILogger<BookingController> _logger;
        private readonly Blanket.Booking.BookingBlanket _BookingBlanket;

        public BookingController(ILogger<BookingController> logger, IFrontDeskUnitOfWork frontDeskUnitOfWork, ManagementService managementService, UserService userService)
        {
            _logger = logger;
            _userService = userService;
            _BookingBlanket = new Blanket.Booking.BookingBlanket(frontDeskUnitOfWork);
        }

        [HttpPost]
        [Route("/api/booking")]
        public async Task<IActionResult> AddBookingDetails([FromBody]BookingRegisterModel bookingModel)
        {
            string userGuid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "System";

            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<string> requiredPermission = new List<string>() { FrontDeskPermissions.AddBooking };

            bool hasPermission = await _userService.HasPermissions(userGuid, requiredPermission);
            if (!hasPermission || userGuid == "System")
                return Unauthorized();

            try
            {
                var httpResponse = await _BookingBlanket.AddBooking(bookingModel, userGuid);
                return Ok(httpResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/booking/{bookingId}")]
        public async Task<IActionResult> GetBookingDetails(int bookingId)
        {
            string userGuid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "System";

            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<string> requiredPermission = new List<string>() { FrontDeskPermissions.ViewBooking };

            bool hasPermission = await _userService.HasPermissions(userGuid, requiredPermission);
            if (!hasPermission || userGuid == "System")
                return Unauthorized();

            try
            {
                var httpResponse = await _BookingBlanket.GetBookingDetails(bookingId);
                return Ok(httpResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}