using B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity;
using SocialNetwork.Shared.Data_Structures;

namespace B_.SocialNetwork.Servicec.Graph.Core.Repositories
{
    public interface IPostRepository
    {
        Task<BST<PostLike>> GetPostLikesAsync(Guid postId);
    }
}
