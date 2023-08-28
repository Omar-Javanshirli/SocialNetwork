using B._SocialNetwork.Services.Graph.Core.Entities.CommentsEntity;

namespace B_.SocialNetwork.Servicec.Graph.Core.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllComment(Guid postId);
    }
}
