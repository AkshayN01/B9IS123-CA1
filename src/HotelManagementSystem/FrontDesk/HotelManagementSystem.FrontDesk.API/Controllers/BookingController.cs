using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library;
using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Contracts.Permissions;
using HotelManagementSystem.Library.Services.Data.FrontDesk;
using HotelManagementSystem.Contracts.APIModels.FontDesk;

namespace HotelManagementSystem.FrontDesk.API.Controllers
{
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ILogger<BookingController> _logger;
        private readonly Blanket.Booking.BookingBlanket _BookingBlanket;

        public BookingController(ILogger<BookingController> logger, IFrontDeskUnitOfWork frontDeskUnitOfWork, ManagementService managementService, UserService userService, HotelBranchService hotelBranchService)
        {
            _logger = logger;
            _userService = userService;
            _BookingBlanket = new Blanket.Booking.BookingBlanket(frontDeskUnitOfWork, hotelBranchService);
        }

        [HttpPost]
        [Route("/api/userGuid/{userGuid}/booking")]
        public async Task<IActionResult> AddBookingDetails(string userGuid, [FromBody]BookingRegisterModel bookingModel)
        {
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

        [HttpPut]
        [Route("/api/userGuid/{userGuid}/booking")]
        public async Task<IActionResult> UpdateBookingDetails(string userGuid, [FromBody] BookingUpdateModel bookingModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<string> requiredPermission = new List<string>() { FrontDeskPermissions.EditBooking };

            bool hasPermission = await _userService.HasPermissions(userGuid, requiredPermission);
            if (!hasPermission || userGuid == "System")
                return Unauthorized();

            try
            {
                var httpResponse = await _BookingBlanket.UpdateBooking(bookingModel, userGuid);
                return Ok(httpResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("/api/userGuid/{userGuid}/booking/{bookingId}")]
        public async Task<IActionResult> UpdateBookingStatus(string userGuid, int bookingId, [FromBody]int statudId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<string> requiredPermission = new List<string>() { FrontDeskPermissions.DeclineBooking };

            bool hasPermission = await _userService.HasPermissions(userGuid, requiredPermission);
            if (!hasPermission || userGuid == "System")
                return Unauthorized();

            try
            {
                var httpResponse = await _BookingBlanket.UpdateBookingStatus(bookingId, statudId, userGuid);
                return Ok(httpResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/userGuid/{userGuid}/booking/{bookingId}")]
        public async Task<IActionResult> GetBookingDetails(string userGuid, int bookingId)
        {
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

        [HttpGet]
        [Route("/api/userguid/{userGuid}/bookings")]
        public async Task<IActionResult> GetAllBookings(string userGuid, string? fromDate, string? toDate, string? status, int pageNumber, int pageSize)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<string> requiredPermission = new List<string>() { FrontDeskPermissions.ViewBooking };

            bool hasPermission = await _userService.HasPermissions(userGuid, requiredPermission);
            if (!hasPermission)
                return Unauthorized();

            try
            {
                var httpResponse = await _BookingBlanket.GetAllBookings(fromDate, toDate, status, pageNumber, pageSize);
                return Ok(httpResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}