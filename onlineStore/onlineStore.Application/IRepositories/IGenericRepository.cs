using onlineStore.Application.Paging;
using onlineStore.Core.Entities;
using System.Linq.Expressions;

namespace onlineStore.Application.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        Task AddAsync(TEntity item);

        Task UpdateAsync(TEntity item);

        Task DeleteAsync(TEntity item);
        
        Task<TEntity> GetOneAsync(int id);
        
        Task<TEntity> GetOneAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters);

        Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters,
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);
        
        
    }
}