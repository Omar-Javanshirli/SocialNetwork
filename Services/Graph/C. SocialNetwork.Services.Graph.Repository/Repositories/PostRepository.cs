using B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity;
using B_.SocialNetwork.Servicec.Graph.Core.Repositories;
using Dapper;

namespace C._SocialNetwork.Services.Graph.Repository.Repositories
{
    public class PostRepository : BaseSqlRepository, IPostRepository
    {
        internal PostRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<List<PostLike>> GetPostLikesAsync(string postId)
        {
            string sqlQuery = $"SELECT * FROM UserPostsViewWithLikes WHERE PostId=@postId";
            using var con = OpenConnection();
            var result = await con.QueryAsync<PostLike>(sqlQuery, new { postId });
            return result.AsList();
        }
    }
}
