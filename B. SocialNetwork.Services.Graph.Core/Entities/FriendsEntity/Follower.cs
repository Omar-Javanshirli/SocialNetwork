﻿namespace B._SocialNetwork.Services.Graph.Core.Entities.FriendsEntity
{
    public class Follower : BaseEntity
    {
        public bool IsRecaiverOrSender { get; set; }
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
