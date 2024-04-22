using HotelManagementSystem.Contracts.APIModels.FontDesk;
using HotelManagementSystem.Contracts.Entities.FrontDesk;
using HotelManagementSystem.Contracts.Enums;
using HotelManagementSystem.Contracts.Generic.Response;
using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library.Services.Data.FrontDesk;
using System.Linq.Expressions;

namespace HotelManagementSystem.FrontDesk.Blanket.Room
{
    public class RoomBlanket
    {
        private readonly IFrontDeskUnitOfWork _frontDeskUnitOfWork;
        private readonly HotelBranchService _hotelBranchService;
        public RoomBlanket(IFrontDeskUnitOfWork frontDeskUnitOfWork, HotelBranchService hotelBranchService) 
        {
            _frontDeskUnitOfWork = frontDeskUnitOfWork;
            _hotelBranchService = hotelBranchService;
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

                retVal = 1;

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

        public async Task<HTTPResponse> GetAllRoom(int roomTypeId, int isAvailable)
        {
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;

            try
            {

                List<Expression<Func<Contracts.Entities.FrontDesk.Room, bool>>> expressions =
                    new List<Expression<Func<Contracts.Entities.FrontDesk.Room, bool>>>();


                Expression<Func<Contracts.Entities.FrontDesk.Room, bool>> roomTypeExpression = x => x.RoomTypeId == roomTypeId;
                expressions.Add(roomTypeExpression);

                //return only those rooms which are available
                if (isAvailable == (int)RoomStatusEnum.Vacant)
                {
                    Expression<Func<Contracts.Entities.FrontDesk.Room, bool>> roomExpression = x => x.Reservations.Count == 0;
                    expressions.Add(roomExpression);
                }

                // Combine the conditions
                var combinedCondition = Library.Generic.Generic.CombineConditions<Contracts.Entities.FrontDesk.Room>(expressions);
                List<Contracts.Entities.FrontDesk.Room> rooms = await _frontDeskUnitOfWork.RoomRepository.GetAllRooms(combinedCondition);
                List<RoomModel> roomModel = rooms
                    .Select(x => new RoomModel() { Id = x.RoomId, RoomName = x.RoomName, RoomNumber = x.RoomNumber, RoomTypeId = x.RoomTypeId })
                    .ToList();
                retVal = 1;

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
