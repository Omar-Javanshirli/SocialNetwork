using B._SocialNetwork.Services.Graph.Core.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace C._SocialNetwork.Services.Graph.Repository.Repositories
{
    public class GenericRepository<T> : BaseSqlRepository, IGenericRepository<T> where T : class
    {
        public GenericRepository(string connectionString)
            : base(connectionString)
        {

        }

        private string GetTableName(string tableName)
        {
            string[] splits = tableName.Split('_');
            tableName = splits[0];
            return tableName;
        }

        public async Task AddAsync(T entity)
        {
            var tableName = GetTableName(typeof(T).Name);
            var properties = typeof(T).GetProperties();
            var columnNames = string.Join(",", properties.Select(property => property.Name));
            var parameterNames = string.Join(",", properties.Select(property => "@" + property.Name));


            var sqlQuery = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";
            using var con = OpenConnection();
            var result = await con.ExecuteAsync(sqlQuery, entity);
        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            string tableName = typeof(T).Name;
            var properties = typeof(T).GetProperties();
            var columnNames = string.Join(",", properties.Select(property => property.Name));
            var parameterNames = string.Join(",", properties.Select(property => "@" + property.Name));

            using var con = OpenConnection();
            foreach (var entity in entities)
            {
                string query = $"INSERT INTO {tableName} VALUES ({parameterNames})";
                await con.ExecuteAsync(query, entity);
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            using var con = OpenConnection();
            return await con.QueryFirstOrDefaultAsync<bool>
                ($"SELECT COUNT(*) FROM {typeof(T).Name} WHERE {expression}", expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            string query = $"SELECT * FROM {typeof(T).Name}";
            using var con = OpenConnection();
            return await con.QueryAsync<T>(query);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            string query = $"SELECT * FROM {typeof(T).Name} WHERE Id = @Id";
            using var con = OpenConnection();
            return await con.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
        }

        public void Remove(T entity)
        {
            string query = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";
            using var con = OpenConnection();
            con.Execute(query, entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            string tableName = typeof(T).Name;
            using var con = OpenConnection();
            foreach (var entity in entities)
            {
                string query = $"DELETE FROM {tableName} WHERE Id = @Id";
                con.Execute(query, entity);
            }
        }

        public void Update(T entity)
        {
            var properties = typeof(T).GetProperties();
            var columnNames = string.Join(",", properties.Select(property => property.Name));
            string query = $"UPDATE {typeof(T).Name} SET Name = {columnNames} WHERE Id = @Id";
            using var con = OpenConnection();
            con.Execute(query, entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            using var con = OpenConnection();
            return con.Query<T>($"SELECT * FROM {typeof(T).Name}").AsQueryable().Where(expression);
        }
    }
}
