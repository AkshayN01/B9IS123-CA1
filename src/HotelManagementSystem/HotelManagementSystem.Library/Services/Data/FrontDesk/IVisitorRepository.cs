using HotelManagementSystem.Contracts.Entities.Visitor;

namespace HotelManagementSystem.Library.Services.Data.FrontDesk
{
    public interface IVisitorRepository : IRepository<Visitor>
    {
        Task<int> AddVisitorDetails(Visitor visitor);
        Task<List<int>> AddMultipleVisitors(List<Visitor> visitors);
        Task<Visitor> GetByBookingId(int branchId, int bookingId);
        Task<List<Visitor>> GetTravelPartner(int visitorId, int bookingId);
     }
}