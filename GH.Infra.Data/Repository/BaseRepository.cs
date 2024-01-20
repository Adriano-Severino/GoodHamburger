using GH.Domain.Entities;
using GH.Domain.Interfaces;
using GH.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GH.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationContext _sqlContext;

        public BaseRepository(ApplicationContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
        public async Task InsertAsync(TEntity obj)
        {
            _sqlContext.Set<TEntity>().Add(obj);
            await _sqlContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TEntity obj)
        {
            _sqlContext.Entry(obj).State = EntityState.Modified;
            await _sqlContext.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            _sqlContext.Set<TEntity>().Remove(SelectAsync(id).Result);
            await _sqlContext.SaveChangesAsync();
            return true;
        }
        public async Task<IList<TEntity>> SelectAsync()
        {
            return await _sqlContext.Set<TEntity>().AsNoTracking().ToListAsync();

        }
        public async Task<TEntity> SelectAsync(Guid id)
        {
            return await _sqlContext.Set<TEntity>().FindAsync(id);
        }
        public async Task<IList<TEntity>> SelectAsync<TEntity>(params Expression<Func<TEntity, object>>[] includes)
   where TEntity : BaseEntity
        {
            var query = _sqlContext.Set<TEntity>().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> SelectAsync<TEntity>(Guid id, params Expression<Func<TEntity, object>>[] includes)
     where TEntity : BaseEntity
        {
            var query = _sqlContext.Set<TEntity>().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
