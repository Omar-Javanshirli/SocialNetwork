using B._SocialNetwork.Services.Graph.Core.Entities.PostEntity;
using SocialNetwork.Shared.Data_Structures;

namespace B._SocialNetwork.Services.Graph.Core.Repositories
{
    public interface IPostRepository
    {
        Task<BST<PostLike>> GetPostLikesAsync(Guid postId);
    }
}
