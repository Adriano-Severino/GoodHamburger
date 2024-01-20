using GH.Domain.Entities;

namespace GH.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        public Task<TOutputModel> AddAsync<TInputModel, TOutputModel>(TInputModel inputModel)
               where TInputModel : class
               where TOutputModel : class;
        public Task<bool> DeleteAsync(Guid id);
        public Task<IEnumerable<TOutputModel>> GetAsync<TOutputModel>() where TOutputModel : class;
        public Task<TOutputModel> GetByIdAsync<TOutputModel>(Guid id) where TOutputModel : class;
        public Task<TOutputModel> GetByEmailAsync<TOutputModel>(string email) where TOutputModel : class;
        public Task<TOutputModel> UpdateAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
               where TInputModel : class
               where TOutputModel : class;
    }
}
