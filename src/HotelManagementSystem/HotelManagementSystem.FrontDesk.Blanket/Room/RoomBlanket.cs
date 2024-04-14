using HotelManagementSystem.Contracts.APIModels.FontDesk;
using HotelManagementSystem.Contracts.Entities.FrontDesk;
using HotelManagementSystem.Contracts.Generic.Response;
using HotelManagementSystem.Library.Services.Data.FrontDesk;

namespace HotelManagementSystem.FrontDesk.Blanket.Room
{
    public class RoomBlanket
    {
        private readonly IFrontDeskUnitOfWork _frontDeskUnitOfWork;
        public RoomBlanket(IFrontDeskUnitOfWork frontDeskUnitOfWork) 
        {
            _frontDeskUnitOfWork = frontDeskUnitOfWork;
        }
        public async Task<HTTPResponse> GetAllRoomTypes()
        {
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;

            try
            {
                IEnumerable<RoomType> roomTypes = await _frontDeskUnitOfWork.RoomTypeRepository.GetAllAsync();
                List<RoomTypeModel> roomTypesModel = roomTypes
                    .Select(x => new RoomTypeModel() { Id = x.Id, MaxCapacity = x.MaxCapacity, Name = x.Name, Price = x.Price })
                    .ToList();

                data = roomTypesModel;
            }
            catch (Exception ex)
            {
                retVal = -50;
                message = ex.Message;
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, message);
            }

            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        }

        public async Task<HTTPResponse> GetAllRoom(int roomTypeId)
        {
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;

            try
            {
                IEnumerable<Contracts.Entities.FrontDesk.Room> rooms = await _frontDeskUnitOfWork.RoomRepository.GetAllAsync();
                List<RoomModel> roomModel = rooms.Where(x => x.RoomTypeId == roomTypeId)
                    .Select(x => new RoomModel() { Id = x.RoomId, RoomName = x.RoomName, RoomNumber = x.RoomNumber, RoomTypeId = x.RoomTypeId })
                    .ToList();

                data = roomModel;
            }
            catch (Exception ex)
            {
                retVal = -50;
                message = ex.Message;
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, message);
            }

            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        }
    }
}
