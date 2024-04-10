using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Library.Services.Data.FrontDesk
{
    public interface IFrontDeskUnitOfWork : IUnitOfWork
    {
        IBookingRepository BookingRepository { get; }
        IRoomRepository RoomRepository { get; }
        IVisitorRepository VisitorRepository { get; }
        IRoomTypeRepository RoomTypeRepository { get; }
    }
}
