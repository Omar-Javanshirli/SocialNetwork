﻿using B._SocialNetwork.Services.Graph.Core.Entities.FriendEntity;
using B._SocialNetwork.Services.Graph.Core.Entities.PostEntity;

namespace B._SocialNetwork.Services.Graph.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<Post>> GetAllUserPostsAsync(Guid userId);
        Task<List<Highlight>> GetAllUserHighlightsAsync(string userId);
        Task<List<Follower>> GetAllUserFollowersAsync(string userId);
        Task<List<Following>> GetAllUserFollowingsAsync(string userId);
    }
}
