using B._SocialNetwork.Services.Graph.Core.Entities.PostEntity;

namespace B._SocialNetwork.Services.Graph.Core.Repositories
{
    public interface IPostRepository
    {
        Task<BST<PostLike>> GetPostLikesAsync(Guid postId);
    }
}
