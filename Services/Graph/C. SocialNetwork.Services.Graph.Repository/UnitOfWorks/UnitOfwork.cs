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

        public UnitOfWork(IConfiguration configuration)
        {
            _connectionString = (configuration.GetConnectionString("DefaultConnection"))!;
        }

        public GenericRepository<dynamic> _genericRepository;
        public UserRepository _userRepository;

        public IGenericRepository<dynamic> genericRepository => _genericRepository ??= new GenericRepository<dynamic>(_connectionString);
        public IUserRepository userRepository => _userRepository ??= new UserRepository(_connectionString);
    }
}
