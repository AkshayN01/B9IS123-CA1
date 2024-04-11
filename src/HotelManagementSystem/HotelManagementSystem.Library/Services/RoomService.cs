using HotelManagementSystem.Contracts.APIModels.FontDesk;
using HotelManagementSystem.Contracts.Entities.FrontDesk;
using HotelManagementSystem.Library.Services.Data.FrontDesk;

namespace HotelManagementSystem.Library.Services
{
    public class RoomService
    {
        public readonly IFrontDeskUnitOfWork _frontDeskUnitOfWork;
        public RoomService(IFrontDeskUnitOfWork frontDeskUnitOfWork)
        {
            _frontDeskUnitOfWork = frontDeskUnitOfWork;
        }
    }
}
