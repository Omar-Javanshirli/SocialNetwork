using B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity;

namespace B_.SocialNetwork.Servicec.Graph.Core.Entities.PostEntity
{
    public class Highlight
    {
        public string Id { get; set; } = null!;
        public List<MediaLink>? MediaLinks { get; set; }
    }
}
