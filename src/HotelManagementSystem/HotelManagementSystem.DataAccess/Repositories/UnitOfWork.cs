using HotelManagementSystem.DataAccess.Repositories.Admin;
using HotelManagementSystem.Library.Services.Data;
using HotelManagementSystem.Library.Services.Data.Admin;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;
        private IHotelBranchRepository _hotelBranchRepository;

        private readonly DbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Rollback changes if needed
        }
        public IUserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_context); }
        }

        public IHotelBranchRepository HotelBranchRepository
        {
            get { return _hotelBranchRepository ??= new HotelBranchRepository(_context); }
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
