using B._SocialNetwork.Services.Graph.Core.Entities.PostEntity;
using B._SocialNetwork.Services.Graph.Core.Repositories;
using Dapper;
using SocialNetwork.Shared.Data_Structures;

namespace C._SocialNetwork.Services.Graph.Repository.Repositories.Post
{
    public class PostRepository : BaseSqlRepository, IPostRepository
    {
        internal PostRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<BST<PostLike>> GetPostLikesAsync(Guid postId)
        {
            string sqlQuery = $"SELECT * FROM UserPostsViewWithLikes WHERE PostId=@postId";
            using var con = OpenConnection();
            var result = await con.QueryAsync<PostLike>(sqlQuery, new { postId });

            var bst = new BST<PostLike>();

            foreach (var postLike in result)
                bst.Tree = bst.Add(bst.Tree, postLike);

            return bst;
        }
    }
}
