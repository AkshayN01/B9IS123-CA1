using HotelManagementSystem.Contracts.Entities.FrontDesk;
using HotelManagementSystem.Library.Services.Data.FrontDesk;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.FrontDesk.DataAccess.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly DbContext _context;
        private DbSet<Room> _rooms;
        public RoomRepository(DbContext context) : base(context)
        {
            _context = context;
            _rooms = _context.Set<Room>();
        }

        public Task<List<Room>> GetAllRooms(int branchId, int roomLevel, int isActive)
        {
            throw new NotImplementedException();
        }

        public Task<Room> GetRoomByBookingId(int branchId, int bookingId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetRoomsByRoomIds(List<int> roomIds)
        {
            return _rooms.Where(x => roomIds.Contains(x.RoomId)).AsEnumerable<Room>();
        }
    }
}
