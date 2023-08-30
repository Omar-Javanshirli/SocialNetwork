using IdentityModel.Client;
using SocialNetwork.Shared.Dtos;
using SocialNetwork.Web.Core.Models.Input;

namespace SocialNetwork.WEB.Core.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<TokenResponse> GetAccessTokenByRefreshTokenAsync();
        Task RevokeRefreshTokenAsync();
        Task<string> GetTokenByClientAsync();
        Task GetRefreshTokenAsync();
        Task<Response<bool>> SigninAsync(SignInInput signInInput);
        public Task<List<string>> SignUpAsync(SignUpInput signUpInput);
        Task<Response<bool>> LogoutAsync();
    }
}
