using HotelManagementSystem.Contracts.Entities.FrontDesk;
using System.Linq.Expressions;

namespace HotelManagementSystem.Library.Services.Data.FrontDesk
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<int> AddBookingDetails(Booking booking);
        Task<List<Booking>> GetAllBookingDetails(Expression<Func<Booking, bool>> condition);
    }
}