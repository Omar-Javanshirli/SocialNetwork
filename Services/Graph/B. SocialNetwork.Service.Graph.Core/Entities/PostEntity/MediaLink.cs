using B._SocialNetwork.Service.Graph.Core;

namespace B._SocialNetwork.Services.Graph.Core.Entities.PostEntity
{
    public class MediaLink : BaseEntity
    {
        public bool IsImage { get; set; }
        public string Url { get; set; } = null!;
        public Guid PostId { get; set; }
        public Post Post { get; set; } = null!;
    }
}
