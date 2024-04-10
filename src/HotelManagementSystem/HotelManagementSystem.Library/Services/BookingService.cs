using HotelManagementSystem.Library.Services.Data.FrontDesk;

namespace HotelManagementSystem.Library.Services
{
    public class BookingService
    {
        public readonly IFrontDeskUnitOfWork _frontDeskUnitOfWork;
        public BookingService(IFrontDeskUnitOfWork frontDeskUnitOfWork) 
        {
            _frontDeskUnitOfWork = frontDeskUnitOfWork;
        }
    }
}
