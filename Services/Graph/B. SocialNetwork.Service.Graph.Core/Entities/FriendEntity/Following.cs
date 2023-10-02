using B._SocialNetwork.Service.Graph.Core;
using B._SocialNetwork.Services.Graph.Core.Entities.UserEntity;

namespace B._SocialNetwork.Services.Graph.Core.Entities.FriendEntity
{
    public class Following : BaseEntity
    {
        public bool IsRecaiverOrSender { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
