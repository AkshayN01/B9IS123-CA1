using HotelManagementSystem.Contracts.Entities.Visitor;

namespace HotelManagementSystem.Library.Services.Data.FrontDesk
{
    public interface IVisitorRepository : IRepository<Visitor>
    {
        Task<Visitor> GetByBookingId(int branchId, int bookingId);
        Task<List<Visitor>> GetTravelPartner(int visitorId, int bookingId);
    }
}
