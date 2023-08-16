using B._SocialNetwork.Services.Graph.Core.Repositories;

namespace B._SocialNetwork.Services.Graph.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public IGenericRepository<dynamic> genericRepository { get; }
    }
}
