using B._SocialNetwork.Services.Graph.Core.Entities.CommentsEntity;
using B_.SocialNetwork.Servicec.Graph.Core.Repositories;
using Dapper;

namespace C._SocialNetwork.Services.Graph.Repository.Repositories
{
    public class CommentRepository : BaseSqlRepository, ICommentRepository
    {
        internal CommentRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<List<Comment>> GetAllComment(Guid postId)
        {
            string sqlQuery = $"SELECT * FROM GetPostComments WHERE PostId={postId}";
            using var con = OpenConnection();
            var result = await con.QueryAsync<Comment>(sqlQuery, new { postId });
            return result.AsList();
        }
    }
}