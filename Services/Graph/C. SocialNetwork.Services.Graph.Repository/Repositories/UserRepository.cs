using B._SocialNetwork.Services.Graph.Core.Entities.FriendsEntity;
using B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity;
using B._SocialNetwork.Services.Graph.Core.Repositories;
using B_.SocialNetwork.Servicec.Graph.Core.Entities.PostEntity;
using B_.SocialNetwork.Servicec.Graph.Core.Repositories;
using Dapper;

namespace C._SocialNetwork.Services.Graph.Repository.Repositories
{
    public class UserRepository : BaseSqlRepository, IUserRepository
    {
        internal UserRepository(string connectionString)
            : base(connectionString)
        {
        }

        public Task<List<Follower>> GetAllUserFollowersAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Following>> GetAllUserFollowingsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Highlight>> GetAllUserHighlightsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Post>> GetAllUserPostsAsync(string userId)
        {
            string sqlQuery = $"SELECT * FROM UserPostsView WHERE UserId = @userId";
            using var con = OpenConnection();
            var result = await con.QueryAsync<Post>(sqlQuery, new { userId });
            return result.AsList();
        }
    }
}
