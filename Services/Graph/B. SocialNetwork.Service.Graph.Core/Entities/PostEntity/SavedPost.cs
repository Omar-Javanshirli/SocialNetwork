using B._SocialNetwork.Service.Graph.Core;
using B._SocialNetwork.Services.Graph.Core.Entities.UserEntity;

namespace B._SocialNetwork.Services.Graph.Core.Entities.PostEntity
{
    public class SavedPost : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public User User { get; set; } = null!;
        public Post Post { get; set; } = null!;
    }
}
