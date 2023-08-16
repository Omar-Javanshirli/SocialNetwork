namespace B._SocialNetwork.Services.Graph.Core.Entities.CommentsEntity
{
    public class CommentLike : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public string CommentId { get; set; } = null!;
        public User User { get; set; } = null!;
        public Comment Comment { get; set; } = null!;
    }
}
