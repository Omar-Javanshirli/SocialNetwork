namespace B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity
{
    public class SavedPost : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public string MyProperty { get; set; } = null!;
        public User User { get; set; } = null!;
        public Post Post { get; set; } = null!;
    }
}
