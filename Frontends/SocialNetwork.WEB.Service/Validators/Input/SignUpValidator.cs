using FluentValidation;
using FluentValidation.Validators;
using SocialNetwork.WEB.Core.Models.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Service.Validators.Input
{
    public class SignUpValidator : AbstractValidator<SignUpInput>
    {
        public SignUpValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email field cannot be left blank")
                .EmailAddress()
                .WithMessage("Email format is wrong")
                .WithName("Email : ");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Username field cannot be left blank")
                .WithName("Username : ");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone field cannot be left blank");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Password field cannot be left blank")
                .MinimumLength(6)
                .WithMessage("Your Password must be at least 6 characters")
                .WithName("Password : ");

            RuleFor(x => x.PasswordConfirm)
                .NotEmpty()
                .WithMessage("Password Confirm filed cannot be left blank")
                .WithName("Password Confirm : ")
                .MinimumLength(6)
                .WithMessage("Your Password must be at least 6 characters")
                .Equal(x => x.Password)
                .WithMessage("Password is not the same");
        }
    }
}
