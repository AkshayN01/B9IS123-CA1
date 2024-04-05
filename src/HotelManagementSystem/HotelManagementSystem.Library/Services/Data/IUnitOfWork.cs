using HotelManagementSystem.Library.Services.Data.Admin;

namespace HotelManagementSystem.Library.Services.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        IUserRepository UserRepository { get; }
        IHotelBranchRepository HotelBranchRepository { get; }
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
