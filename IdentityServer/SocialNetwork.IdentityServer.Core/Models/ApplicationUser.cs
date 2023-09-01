using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.IdentityServer.Core.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Fullname { get; set; }
        public Gender Gender { get; set; }
    }
}
