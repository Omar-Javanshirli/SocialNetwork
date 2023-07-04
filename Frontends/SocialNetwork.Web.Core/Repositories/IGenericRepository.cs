using System.Linq.Expressions;

namespace SocialNetwork.Web.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        void RemoveAsync(TEntity entity);
        TEntity UpdateAsync(TEntity entity);
    }
}
