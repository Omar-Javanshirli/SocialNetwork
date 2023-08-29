using B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity;

namespace B._SocialNetwork.Services.Graph.Core.Entities.CommentsEntity
{
    public class Comment : BaseEntity
    {
        public string CommentText { get; set; } = null!;
        public string? ParentCommentId { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; } 
        public Post Post { get; set; } = null!;
        public User User { get; set; } = null!;
        public List<CommentLike>? CommenstLike { get; set; }
    }
}