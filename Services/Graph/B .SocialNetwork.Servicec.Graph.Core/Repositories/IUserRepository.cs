using B._SocialNetwork.Services.Graph.Core.Entities.FriendsEntity;
using B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity;
using B_.SocialNetwork.Servicec.Graph.Core.Entities.PostEntity;

namespace B_.SocialNetwork.Servicec.Graph.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<Post>> GetAllUserPostsAsync(string userId);
        Task<List<Highlight>>GetAllUserHighlightsAsync(string userId);
        Task <List<Follower>>GetAllUserFollowersAsync(string userId);
        Task<List<Following>>GetAllUserFollowingsAsync(string userId);
    }
}
