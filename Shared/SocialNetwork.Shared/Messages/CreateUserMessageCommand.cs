using System;

namespace SocialNetwork.Shared.Messages
{
    public class CreateUserMessageCommand
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
