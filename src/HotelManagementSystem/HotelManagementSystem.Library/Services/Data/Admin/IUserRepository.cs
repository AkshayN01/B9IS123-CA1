using HotelManagementSystem.Contracts.Entities.Admin;

namespace HotelManagementSystem.Library.Services.Data.Admin
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByGuid(Guid guid);
        Task<User> GetUserByUsernameAsync(string username, int branchId);
    }
}
