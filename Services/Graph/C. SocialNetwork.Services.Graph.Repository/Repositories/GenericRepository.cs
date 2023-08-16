using B._SocialNetwork.Services.Graph.Core.Repositories;
using Dapper;
using System.Data;
using System.Linq.Expressions;

namespace C._SocialNetwork.Services.Graph.Repository.Repositories
{
    public class GenericRepository<T> : BaseSqlRepository, IGenericRepository<T> where T : class
    {
        private readonly IDbConnection _connection;

        public GenericRepository(string connectionString)
            : base(connectionString)
        {
            _connection = OpenConnection();
        }

        public async Task AddAsync(T entity)
        {
            var properties = typeof(T).GetProperties();
            var columnNames = string.Join(",", properties.Select(property => property.Name));
            var parameterNames = string.Join(",", properties.Select(property => "@" + property.Name));

            var saveStatus = await _connection.ExecuteAsync(
                $"INSERT INTO {typeof(T).Name} ({columnNames}) VALUES ({parameterNames})",
                entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            string tableName = typeof(T).Name;
            var properties = typeof(T).GetProperties();
            var columnNames = string.Join(",", properties.Select(property => property.Name));
            var parameterNames = string.Join(",", properties.Select(property => "@" + property.Name));

            foreach (var entity in entities)
            {
                string query = $"INSERT INTO {tableName} VALUES ({parameterNames})";
                await _connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _connection.QueryFirstOrDefaultAsync<bool>
                ($"SELECT COUNT(*) FROM {typeof(T).Name} WHERE {expression}", expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            string query = $"SELECT * FROM {typeof(T).Name}";
            return await _connection.QueryAsync<T>(query);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            string query = $"SELECT * FROM {typeof(T).Name} WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
        }

        public void Remove(T entity)
        {
            string query = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";
            _connection.Execute(query, entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            string tableName = typeof(T).Name;

            foreach (var entity in entities)
            {
                string query = $"DELETE FROM {tableName} WHERE Id = @Id";
                _connection.Execute(query, entity);
            }
        }

        public void Update(T entity)
        {
            var properties = typeof(T).GetProperties();
            var columnNames = string.Join(",", properties.Select(property => property.Name));
            string query = $"UPDATE {typeof(T).Name} SET Name = {columnNames} WHERE Id = @Id";

            _connection.Execute(query, entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _connection.Query<T>($"SELECT * FROM {typeof(T).Name}").AsQueryable().Where(expression);
        }
    }
}
