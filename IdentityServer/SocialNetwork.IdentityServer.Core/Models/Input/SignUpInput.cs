using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.IdentityServer.Core.Models.Input
{
    public class SignUpInput
    {
        public string Fullname { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public Gender Gender { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; } = null!;
    }
}
