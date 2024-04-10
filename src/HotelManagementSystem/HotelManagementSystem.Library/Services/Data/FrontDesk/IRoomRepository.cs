using HotelManagementSystem.Contracts.Entities.FrontDesk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Library.Services.Data.FrontDesk
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room> GetRoomByBookingId(int branchId, int bookingId);
        Task<List<Room>> GetAllRooms(int branchId, int roomLevel, int isActive);
    }
}
