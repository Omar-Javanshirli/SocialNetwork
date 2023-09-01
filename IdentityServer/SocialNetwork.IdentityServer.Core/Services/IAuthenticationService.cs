using SocialNetwork.IdentityServer.Core.Models;
using SocialNetwork.IdentityServer.Core.Models.Input;
using SocialNetwork.Shared.Dtos;
using System.Threading.Tasks;

namespace SocialNetwork.IdentityServer.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<ApplicationUser>> SignUpAsync(SignUpInput input);
    }
}
