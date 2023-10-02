using B._SocialNetwork.Services.Graph.Core.Entities.UserEntity;

namespace B._SocialNetwork.Services.Graph.Core.Entities.CommentEntity
{
    public class CommentLike:BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }
        public User User { get; set; } = null!;
        public Comment Comment { get; set; } = null!;
    }
}
