using HotelManagementSystem.Library.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public void Delete(TEntity obj) => _dbSet.Remove(obj);

        public void Delete(IEnumerable<TEntity> list) => _dbSet.RemoveRange(list);

        public TEntity Get(long id) => _dbSet.Find(id);

        public IEnumerable<TEntity> GetAll() => _dbSet.ToList();

        public void Insert(TEntity obj) => _dbSet.Add(obj);

        public void Insert(IEnumerable<TEntity> list) => _dbSet.AddRange(list);

        public void Update(TEntity obj) => _context.Entry(obj).State = EntityState.Modified;

        public async Task<TEntity> GetAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task InsertAsync(TEntity obj) => await _dbSet.AddAsync(obj);

        public async Task InsertAsync(IEnumerable<TEntity> list) => await _dbSet.AddRangeAsync(list);
    }
}
