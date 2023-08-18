﻿using B._SocialNetwork.Services.Graph.Core.Entities.CommentsEntity;
using B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity;

namespace D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Response
{
    public class GetAllUserPostsQueryResponse
    {
        public string Id { get; set; } = null!;
        public string  UserId { get; set; }=null!;
        public List<Comment>? Comments { get; set; }
        public List<PostLike>? Likes { get; set; }
        public List<MediaLink> MediaLinks { get; set; }=null!;
    }
}