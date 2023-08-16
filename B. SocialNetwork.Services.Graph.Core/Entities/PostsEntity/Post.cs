using B._SocialNetwork.Services.Graph.Core.Entities.CommentsEntity;

namespace B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity
{
    public class Post : BaseEntity
    {
        public bool Like { get; set; }
        public bool SavePost { get; set; }
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public List<Comment>? Comments { get; set; }
        public List<PostLike>? Likes { get; set; }
        public List<MediaLink> MediaLinks { get; set; } = null!;
        public List<SavedPost>? SavedPosts { get; set; }
    }
}
