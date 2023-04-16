using FordInternHW2.Data.Context;
using FordInternHW2.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW2.Data.Repository.Concrete
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity: class
    {
        private readonly AppDbContext context;
        private DbSet<TEntity> entities;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            entities.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int entityId)
        {
            return await entities.FindAsync(entityId);
        }

        public async Task PostAsync(TEntity entity)
        {
            await entities.AddAsync(entity);
        }

        public void Put(TEntity entity)
        {
            entities.Update(entity);
        }

        public List<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            return entities.Where(where).ToList();
        }
    }
}
