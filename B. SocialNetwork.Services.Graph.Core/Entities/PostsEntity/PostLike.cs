namespace B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity
{
    public class PostLike : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public string PostId { get; set; } = null!;
        public User User { get; set; } = null!;
        public Post Post { get; set; } = null!;
    }
}
