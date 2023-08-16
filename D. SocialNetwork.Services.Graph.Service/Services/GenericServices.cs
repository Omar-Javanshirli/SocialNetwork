using B._SocialNetwork.Services.Graph.Core.Repositories;
using B._SocialNetwork.Services.Graph.Core.Services;
using D._SocialNetwork.Services.Graph.Service.Exceptions;
using System.Linq.Expressions;

namespace D._SocialNetwork.Services.Graph.Service.Services
{
    public class GenericServices<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericServices(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var hasProduct = await _repository.GetByIdAsync(id);

            if (hasProduct == null)
                throw new NotFoundException($"{typeof(T).Name} not found");

            return hasProduct;
        }

        public void Remove(T entity)
        {
           _repository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        { 
            _repository.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
