using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW2.Data.Repository.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int entityId);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task PostAsync(TEntity entity);
        void Put(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> Where(System.Linq.Expressions.Expression<Func<TEntity, bool>> where);
    }
}
