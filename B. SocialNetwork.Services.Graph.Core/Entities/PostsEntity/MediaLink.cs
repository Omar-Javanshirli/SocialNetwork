namespace B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity
{
    public class MediaLink : BaseEntity
    {
        public bool IsImage { get; set; }
        public string Url { get; set; } = null!;
        public string PostId { get; set; } = null!;
        public Post Post { get; set; } = null!;
    }
}
