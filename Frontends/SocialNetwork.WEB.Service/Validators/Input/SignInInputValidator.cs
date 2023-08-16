using FluentValidation;
using SocialNetwork.Web.Core.Models.Input;

namespace SocialNetwork.Web.Service.Validators.Input
{
    public class SignInInputValidator : AbstractValidator<SignInInput>
    {
        public SignInInputValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .WithName("Email");


            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .WithName("Password");
        }
    }
}
