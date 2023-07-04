using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SocialNetwork.Web.Core.Models.Input
{
    public class SignInInput
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }
    }
}
