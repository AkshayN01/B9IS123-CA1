using HotelManagementSystem.Contracts.Entities.FrontDesk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Library.Services.Data.FrontDesk
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room> GetRoomByBookingId(int branchId, int bookingId);
        Task<List<Room>> GetAllRooms(Expression<Func<Room, bool>> expression);

        IEnumerable<Room> GetRoomsByRoomIds(List<int> roomIds);
    }
}
