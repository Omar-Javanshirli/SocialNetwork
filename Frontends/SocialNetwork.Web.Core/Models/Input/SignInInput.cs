using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.WEB.Core.Models.Input
{
    public class SignInInput
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }
    }
}
