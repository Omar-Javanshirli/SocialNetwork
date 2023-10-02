using SocialNetwork.WEB.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.WEB.Core.Models.Input
{
    public class SignUpInput
    {
        public SignUpInput()
        {
        }


        public SignUpInput(string username, string password, string fullname, string phone, string email, string userName, Gender gender)
        {
            UserName = userName;
            Email = email;
            Phone = phone;
            Password = password;
            Gender = gender;
            Fullname = fullname;
        }

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
