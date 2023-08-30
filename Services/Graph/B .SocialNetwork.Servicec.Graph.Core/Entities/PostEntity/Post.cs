using B._SocialNetwork.Services.Graph.Core.Entities.CommentsEntity;
using SocialNetwork.Shared.Data_Structures;

namespace B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity
{
    public class Post : BaseEntity
    {
        public bool Like { get; set; }
        public bool SavePost { get; set; }
        public Guid UserId { get; set; } 
        public User User { get; set; } = null!;
        public List<Comment>? Comments { get; set; }
        public BST<PostLike>? Likes { get; set; }
        public List<MediaLink> MediaLinks { get; set; } = null!;
        public List<SavedPost>? SavedPosts { get; set; }
    }
}
