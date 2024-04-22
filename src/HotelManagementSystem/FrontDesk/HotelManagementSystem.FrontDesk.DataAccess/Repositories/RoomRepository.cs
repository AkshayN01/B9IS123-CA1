using HotelManagementSystem.Contracts.Entities.FrontDesk;
using HotelManagementSystem.Library.Services.Data.FrontDesk;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<List<Room>> GetAllRooms(Expression<Func<Room, bool>> expression)
        {
            return await _rooms.Include(r => r.Reservations).Where(expression).ToListAsync();
        }

        public Task<Room> GetRoomByBookingId(int branchId, int bookingId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetRoomsByRoomIds(List<int> roomIds)
        {
            return _rooms.Where(x => roomIds.Contains(x.RoomId)).Include(x => x.RoomType).AsEnumerable<Room>();
        }
    }
}
