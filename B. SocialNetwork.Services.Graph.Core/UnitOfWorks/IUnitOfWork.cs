using Microsoft.Data.SqlClient;

namespace B._SocialNetwork.Services.Graph.Core.UnitOfWorks
{
    public interface IUnitOfWorkForDapper : IDisposable
    {
        SqlTransaction BeginTransaction();
        SqlConnection GetConnection();
        SqlTransaction GetTransaction();
        void SaveChanges();
    }
}
