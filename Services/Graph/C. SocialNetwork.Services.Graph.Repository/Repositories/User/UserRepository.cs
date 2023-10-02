using B._SocialNetwork.Services.Graph.Core.Entities.FriendEntity;
using B._SocialNetwork.Services.Graph.Core.Entities.PostEntity;
using B._SocialNetwork.Services.Graph.Core.Repositories;
using Dapper;
using PostEntity =B._SocialNetwork.Services.Graph.Core.Entities.PostEntity;

namespace C._SocialNetwork.Services.Graph.Repository.Repositories.User
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

        public async Task<List<PostEntity.Post>> GetAllUserPostsAsync(Guid userId)
        {
            string sqlQuery = $"SELECT * FROM UserPostsView WHERE UserId = @userId";
            using var con = OpenConnection();
            var result = await con.QueryAsync<PostEntity.Post>(sqlQuery, new { userId });
            return result.AsList();
        }
    }
}
