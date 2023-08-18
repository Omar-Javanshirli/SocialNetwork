using B._SocialNetwork.Services.Graph.Core.Repositories;
using B._SocialNetwork.Services.Graph.Core.UnitOfWorks;
using B_.SocialNetwork.Servicec.Graph.Core.Repositories;
using C._SocialNetwork.Services.Graph.Repository.Repositories;
using Microsoft.Extensions.Configuration;

namespace C._SocialNetwork.Services.Graph.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        public UserRepository _userRepository;

        public UnitOfWork(IConfiguration configuration)
        {
            _connectionString = (configuration.GetConnectionString("DefaultConnection"))!;
        }

        public IGenericRepository<T> GetGenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_connectionString);
        }


        public IUserRepository userRepository => _userRepository ??= new UserRepository(_connectionString);
    }
}
