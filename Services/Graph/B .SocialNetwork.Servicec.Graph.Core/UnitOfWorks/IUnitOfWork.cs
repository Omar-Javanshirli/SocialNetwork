using B._SocialNetwork.Services.Graph.Core.Repositories;
using B_.SocialNetwork.Servicec.Graph.Core.Repositories;

namespace B._SocialNetwork.Services.Graph.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public IGenericRepository<dynamic> genericRepository { get; }
        public IUserRepository userRepository { get; }
    }
}