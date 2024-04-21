using HotelManagementSystem.Contracts.Entities.FrontDesk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Library.Services.Data.FrontDesk
{
    public interface IReservationRepository : IRepository<RoomReservation>
    {
        Task AddReservationDetails(List<RoomReservation> roomReservations);

        Task UpdateReservationDetails(List<RoomReservation> roomReservations);
        IEnumerable<RoomReservation> GetRoomReservationsByBookingId(int bookingId);
    }
}