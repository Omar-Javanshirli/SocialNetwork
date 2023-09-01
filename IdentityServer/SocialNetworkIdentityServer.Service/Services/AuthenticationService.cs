using Microsoft.AspNetCore.Identity;
using SocialNetwork.IdentityServer.Core.Models;
using SocialNetwork.IdentityServer.Core.Models.Input;
using SocialNetwork.IdentityServer.Core.Services;
using SocialNetwork.Shared.Dtos;
using SocialNetwork.Shared.Messages;
using System;
using System.Threading.Tasks;
using Mass = MassTransit;

namespace SocialNetworkIdentityServer.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Mass.IPublishEndpoint _publishEndpoint;
        public AuthenticationService(UserManager<ApplicationUser> userManager, Mass.IPublishEndpoint publishEndpoint)
        {
            _userManager = userManager;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Response<ApplicationUser>> SignUpAsync(SignUpInput input)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = input.Username,
                Email = input.Email
            };
            var result = await _userManager.CreateAsync(user, input.Password);

            if (result is { Succeeded: false })
                return Response<ApplicationUser>.Fail("Password or Email is wrong", 400);

            await _publishEndpoint.Publish<CreateUserMessageCommand>
               (new CreateUserMessageCommand
               {
                   UserId = Guid.Parse(user.Id),
                   Email = user.Email,
                   Username=user.UserName,
               });

            return Response<ApplicationUser>.Success(user, 204);
        }
    }
}
