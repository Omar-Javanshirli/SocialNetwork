﻿namespace B._SocialNetwork.Services.Graph.Core.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
        public string? Fullname { get; set; }
        public bool IsOnline { get; set; }
        public bool IsPrivate { get; set; }
        public Gender Gender { get; set; }
        public List<Post>? Posts { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<PostLike>? PostsLike { get; set; }
        public List<CommentLike>? CommenstLike { get; set; }
        public List<SavedPost>? SavedPosts { get; set; }
        public List<Follower>? Followers { get; set; }
        public List<Following>? Followings { get; set; }
    }
}
