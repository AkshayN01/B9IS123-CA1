using HotelManagementSystem.Contracts.Entities.Admin;

namespace HotelManagementSystem.Library.Services.Data.Admin
{
    public interface IHotelBranchRepository : IRepository<HotelBranch>
    {
        Task<HotelBranch> GetCurrentBranchAsync();
    }
}
