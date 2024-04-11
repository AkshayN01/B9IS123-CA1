using HotelManagementSystem.FrontDesk.DataAccess.Repositories;
using HotelManagementSystem.Library.Services.Data.FrontDesk;

namespace HotelManagementSystem.FrontDesk.DataAccess
{
    public class FrontDeskUnitOfWork : IFrontDeskUnitOfWork
    {
        private IRoomRepository? _roomRepository;
        private IBookingRepository? _bookingRepository;
        private IVisitorRepository? _visitorRepository;
        private IRoomTypeRepository? _roomTypeRepository;
        private IReservationRepository? _reservationRepository;
        private ITravelPartnerRepository? _travelPartnerRepository;

        private readonly FrontDeskDbContext _context;
        public FrontDeskUnitOfWork(FrontDeskDbContext context)
        {
            _context = context;
        }

        public IBookingRepository BookingRepository => _bookingRepository ??= new BookingRepository(_context);

        public IRoomRepository RoomRepository => _roomRepository ??= new RoomRepository(_context);

        public IVisitorRepository VisitorRepository => _visitorRepository ??= new VisitorRepository(_context);

        public IRoomTypeRepository RoomTypeRepository => _roomTypeRepository ??= new RoomTypeRepository(_context);
        public IReservationRepository ReservationRepository => _reservationRepository ??= new ReservationRepository(_context);
        public ITravelPartnerRepository TravelPartnerRepository => _travelPartnerRepository ??= new TravelPartnerRepository(_context);


        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
