using B._SocialNetwork.Services.Graph.Core.Repositories;
using B._SocialNetwork.Services.Graph.Core.UnitOfWorks;
using C._SocialNetwork.Services.Graph.Repository.Repositories;
using C._SocialNetwork.Services.Graph.Repository.Repositories.Comment;
using C._SocialNetwork.Services.Graph.Repository.Repositories.Post;
using C._SocialNetwork.Services.Graph.Repository.Repositories.User;
using Microsoft.Extensions.Configuration;

namespace C._SocialNetwork.Services.Graph.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        public UserRepository _userRepository;
        public PostRepository _postRepository;
        public CommentRepository _commentRepository;

        public UnitOfWork(IConfiguration configuration)
        {
            _connectionString = (configuration.GetConnectionString("DefaultConnection"))!;
        }

        public IGenericRepository<T> GetGenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_connectionString);
        }

        public IUserRepository userRepository => _userRepository ??= new UserRepository(_connectionString);

        public IPostRepository postRepository => _postRepository ??= new PostRepository(_connectionString);

        public ICommentRepository commentRepository => _commentRepository??= new CommentRepository(_connectionString);
    }
}
