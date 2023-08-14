using B._SocialNetwork.Services.Graph.Core.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq.Expressions;

namespace C._SocialNetwork.Services.Graph.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDbConnection _connection;
        private readonly IConfiguration _configuration;

        public GenericRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConn"));
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
            foreach (var entity in entities)
                await AddAsync(entity);
        }

        private string GenerateSqlFromExpression(Expression<Func<T, bool>> expression)
        {
            if (expression.Body is BinaryExpression binaryExpression)
            {
                var left = binaryExpression.Left;
                var right = binaryExpression.Right;

                var leftMember = (MemberExpression)left;
                var rightConstant = (ConstantExpression)right;

                var columnName = leftMember.Member.Name;
                var value = rightConstant.Value;

                return $"{columnName} = '{value}'";
            }

            throw new NotSupportedException("Expression type not supported.");
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            var tableName = typeof(T).Name;

            // LINQ ifadesini Lambda ifadesine dönüştürme
            var lambda = expression.Compile();
            var idColumnName = "Id";

            var query = $"SELECT COUNT(*) FROM {tableName} WHERE {idColumnName} IN " +
                        "(SELECT {idColumnName} FROM {tableName} " +
                        "WHERE {GenerateSqlFromExpression(lambda)})";

            var count = await _connection.ExecuteScalarAsync<int>(query);

            return count > 0;
        }

        public  IQueryable<T> GetAll()
        {
            var tableName=typeof(T).Name;
            var query = $"SELECT * FROM {tableName}";
            var result = _connection.Query<T>(query);
            return result.AsQueryable();
        }

        public Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
