namespace B._SocialNetwork.Services.Graph.Core.Entities.FriendsEntity
{
    public class Follower : BaseEntity
    {
        public bool IsRecaiverOrSender { get; set; }
        public Guid UserId { get; set; } 
        public User User { get; set; } = null!;
    }
}
