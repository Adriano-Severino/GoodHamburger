using GH.Domain.Entities;
using System.Linq.Expressions;

namespace GH.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public Task InsertAsync(TEntity obj);
        public Task UpdateAsync(TEntity obj);
        public Task<bool> DeleteAsync(Guid id);
        public Task<IList<TEntity>> SelectAsync();
        public Task<TEntity> SelectAsync(Guid id);
        public Task<IList<TEntity>> SelectAsync<TEntity>(params Expression<Func<TEntity, object>>[] includes)
     where TEntity : BaseEntity;
        public Task<TEntity> SelectAsync<TEntity>(Guid id, params Expression<Func<TEntity, object>>[] includes)
    where TEntity : BaseEntity;


    }
}
