using B._SocialNetwork.Services.Graph.Core.Entities.CommentEntity;
using B._SocialNetwork.Services.Graph.Core.Repositories;
using CommentEntity = B._SocialNetwork.Services.Graph.Core.Entities.CommentEntity;
using Dapper;

namespace C._SocialNetwork.Services.Graph.Repository.Repositories.Comment
{
    public class CommentRepository : BaseSqlRepository, ICommentRepository
    {
        internal CommentRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<List<CommentEntity.Comment>> GetAllComment(Guid postId)
        {
            string sqlQuery = $"SELECT * FROM GetPostComments WHERE PostId={postId}";
            using var con = OpenConnection();
            var result = await con.QueryAsync<CommentEntity.Comment>(sqlQuery, new { postId });
            return result.AsList();
        }

        public async Task<List<CommentLike>> GetAllCommentLike(Guid commentId)
        {
            string sqlQuery = $"SELECT * FROM GetCommentLike WHERE CommentId={commentId}";
            using var con = OpenConnection();
            var result = await con.QueryAsync<CommentLike>(sqlQuery, new { commentId });
            return result.AsList();
        }
    }
}