using B._SocialNetwork.Services.Graph.Core.Entities.CommentEntity;

namespace B._SocialNetwork.Services.Graph.Core.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllComment(Guid postId);
        Task<List<CommentLike>> GetAllCommentLike(Guid commentId);
    }
}
