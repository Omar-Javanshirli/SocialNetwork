using IdentityModel.Client;
using SocialNetwork.Shared.Dtos;
using SocialNetwork.Web.Core.Models.Input;

namespace SocialNetwork.Web.Core.Services
{
    public interface IAuthenticationService
    {
        Task<TokenResponse> GetAccessTokenByRefreshTokenAsync();
        Task RevokeRefreshTokenAsync();
        Task<String> GetTokenByClientAsync();
        Task GetRefreshTokenAsync();
        Task<Response<bool>> SigninAsync(SignInInput signInInput);
        public Task<List<string>> SignUpAsync(Core.Models.Input.SignUpInput signUpInput);
        Task<Response<bool>> LogoutAsync(); 
    }
}
