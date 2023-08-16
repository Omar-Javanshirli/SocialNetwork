using System.Linq.Expressions;

namespace B._SocialNetwork.Services.Graph.Core.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
