using Microsoft.AspNetCore.Identity;
using SocialNetwork.IdentityServer.Core.Models;
using SocialNetwork.IdentityServer.Core.Models.Input;
using SocialNetwork.IdentityServer.Core.Services;
using SocialNetwork.Shared.Dtos;
using System.Threading.Tasks;

namespace SocialNetworkIdentityServer.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<ApplicationUser>> SignUpAsync(SignUpInput input)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = input.UserName,
                Email = input.Email,
                Fullname= input.Fullname,
                PhoneNumber=input.Phone,
                Gender = input.Gender
            };
            var result = await _userManager.CreateAsync(user, input.Password);

            if (result is { Succeeded: false })
                return Response<ApplicationUser>.Fail("Password or Email is wrong", 400);

            return Response<ApplicationUser>.Success(user, 204);
        }
    }
}
