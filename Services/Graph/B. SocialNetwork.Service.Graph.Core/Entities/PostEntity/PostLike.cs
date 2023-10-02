using B._SocialNetwork.Service.Graph.Core;
using B._SocialNetwork.Services.Graph.Core.Entities.UserEntity;

namespace B._SocialNetwork.Services.Graph.Core.Entities.PostEntity
{
    public class PostLike:BaseEntity, IComparable<PostLike>
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public User User { get; set; } = null!;
        public Post Post { get; set; } = null!;

        public int CompareTo(PostLike? other)
        {
            if (other == null)
                return 1;

            return string.Compare(Id.ToString(), other.Id.ToString(), StringComparison.Ordinal);
        }
    }
}
