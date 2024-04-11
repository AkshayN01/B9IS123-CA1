using HotelManagementSystem.Contracts.Entities.FrontDesk;
using HotelManagementSystem.Contracts.Entities.Visitor;
using HotelManagementSystem.Library.Services.Data.FrontDesk;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.FrontDesk.DataAccess.Repositories
{
    public class ReservationRepository : Repository<RoomReservation>, IReservationRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<RoomReservation> _dbSet;
        public ReservationRepository(DbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<RoomReservation>();
        }

        public async Task AddReservationDetails(List<RoomReservation> roomReservations)
        {
            foreach (RoomReservation reservation in roomReservations)
            {
                _context.Add<RoomReservation>(reservation);
            }
            await _context.SaveChangesAsync();
        }
    }
}
