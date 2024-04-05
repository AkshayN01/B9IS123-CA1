using HotelManagementSystem.Library.Services.Data.Admin;

namespace HotelManagementSystem.Library.Services.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
