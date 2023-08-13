using B._SocialNetwork.Services.Graph.Core.UnitOfWorks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SocialNetwork.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C._SocialNetwork.Services.Graph.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        private bool disposed = false;

        private SqlTransaction sqlTransaction = null!;
        private SqlConnection sqlConnection;

        public UnitOfWork(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
            sqlConnection = new SqlConnection(_connectionString);
        }

        public SqlTransaction BeginTransaction()
        {
            if (sqlConnection.State != System.Data.ConnectionState.Open)
            {
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction();
            }

            return sqlTransaction;
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

        public SqlTransaction GetTransaction()
        {
            return sqlTransaction;
        }

        public void Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    sqlTransaction = new NoContent;

                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    sqlConnection.Close();

                disposed = true;
            }
        }

        public void SaveChanges()
        {
            sqlTransaction.Commit();
            sqlConnection.Close();
            sqlTransaction = null;
        }

        ~UnitOfWork() { Dispose(false); }
    }
}
