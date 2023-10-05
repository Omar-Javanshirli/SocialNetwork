using System;

namespace SocialNetwork.SharedForIdentityServer.Messages
{
    public class CreateUserMessageEvent
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
