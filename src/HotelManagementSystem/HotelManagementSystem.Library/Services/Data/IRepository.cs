using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Library.Services.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(long id);
        Task<TEntity> GetAsync(int id);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        void Insert(TEntity obj);
        Task InsertAsync(TEntity obj);

        void Insert(IEnumerable<TEntity> list);
        Task InsertAsync(IEnumerable<TEntity> list);

        void Update(TEntity obj);

        void Delete(TEntity obj);

        void Delete(IEnumerable<TEntity> list);
    }
}
