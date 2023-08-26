using B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity;

namespace B_.SocialNetwork.Servicec.Graph.Core.Repositories
{
    public interface IPostRepository
    {
        Task<List<PostLike>> GetPostLikesAsync(string postId);
    }
}
