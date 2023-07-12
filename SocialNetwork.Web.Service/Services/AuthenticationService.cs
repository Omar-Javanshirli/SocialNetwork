using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using SocialNetwork.Shared.Dtos;
using SocialNetwork.Web.Core.Models.Input;
using SocialNetwork.Web.Core.Models.Settings;
using System.Globalization;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace SocialNetwork.Web.Service.Services
{
    public class AuthenticationService : SocialNetwork.Web.Core.Services.IAuthenticationService
    {
        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClientSetting clientSetting;
        private readonly ServiceApiSetting serviceApiSetting;
        private readonly IClientAccessTokenCache clientAccessTokenCache;

        public AuthenticationService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor,
            IClientAccessTokenCache clientAccessTokenCache, IOptions<ClientSetting> clientSetting,
            IOptions<ServiceApiSetting> serviceApiSetting)
        {
            this.httpClient = httpClient;
            this.httpContextAccessor = httpContextAccessor;
            this.clientAccessTokenCache = clientAccessTokenCache;
            this.serviceApiSetting = serviceApiSetting.Value;
            this.clientSetting = clientSetting.Value;
        }

        public async Task<TokenResponse> GetAccessTokenByRefreshTokenAsync()
        {
            var disco = await this.httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = this.serviceApiSetting.IdentityBaseUri
            });

            if (disco is { IsError: true })
                throw disco.Exception!;

            var refreshToken = await this.httpContextAccessor.HttpContext!.GetTokenAsync
                (OpenIdConnectParameterNames.RefreshToken);

            RefreshTokenRequest refreshTokenRequest = new()
            {
                ClientId = this.clientSetting.WebClientForUser.ClientId,
                ClientSecret = this.clientSetting.WebClientForUser.ClientSecret,
                RefreshToken = refreshToken!,
                Address = disco.TokenEndpoint
            };

            var token = await this.httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

            if (token is { IsError: true })
                return null;

            var authenticationToken = new List<AuthenticationToken>()
            {
                new AuthenticationToken{Name=OpenIdConnectParameterNames.AccessToken,Value=token.AccessToken!},
                new AuthenticationToken{Name = OpenIdConnectParameterNames.RefreshToken,Value=token.RefreshToken!},
                new AuthenticationToken{Name=OpenIdConnectParameterNames.ExpiresIn,
                Value=DateTime.Now.AddSeconds(token.ExpiresIn).ToString("o",CultureInfo.InvariantCulture)}
            };

            var authenticationResult = await this.httpContextAccessor.HttpContext!.AuthenticateAsync();
            var properties = authenticationResult.Properties;
            properties!.StoreTokens(authenticationToken);

            await this.httpContextAccessor.HttpContext!.SignInAsync
                (CookieAuthenticationDefaults.AuthenticationScheme, authenticationResult.Principal!, properties);

            return token;
        }

        public async Task GetRefreshTokenAsync()
        {
            var disco = await this.httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = this.serviceApiSetting.IdentityBaseUri,
            });

            if (disco is { IsError: true })
                throw disco.Exception!;

            var refreshToken = await this.httpContextAccessor.HttpContext!.GetTokenAsync
            (OpenIdConnectParameterNames.RefreshToken);

            RefreshTokenRequest refreshTokenRequest = new RefreshTokenRequest()
            {
                ClientId = this.clientSetting.WebClientForUser.ClientId,
                ClientSecret = this.clientSetting.WebClientForUser.ClientSecret,
                Address = disco.RevocationEndpoint,
                RefreshToken = refreshToken!,
            };

            var token = await this.httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

            if (token is { IsError: true })
                throw token.Exception!;

            var tokens = new List<AuthenticationToken>()
            {

                new AuthenticationToken{ Name=OpenIdConnectParameterNames.IdToken,Value= token.IdentityToken!},
                new AuthenticationToken{ Name=OpenIdConnectParameterNames.AccessToken,Value= token.AccessToken!},
                new AuthenticationToken{ Name=OpenIdConnectParameterNames.RefreshToken,Value= token.RefreshToken!},
                new AuthenticationToken{ Name=OpenIdConnectParameterNames.ExpiresIn,
                    Value= DateTime.UtcNow.AddSeconds(token.ExpiresIn).ToString("o", CultureInfo.InvariantCulture)}
            };

            var authenticationResult = await this.httpContextAccessor.HttpContext!.AuthenticateAsync();
            var properties = authenticationResult.Properties;
            properties!.StoreTokens(tokens);

            await this.httpContextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                authenticationResult.Principal!, properties);
        }

        public async Task<string> GetTokenByClientAsync()
        {
            var currentToken = await this.clientAccessTokenCache.GetAsync
                ("WebClientToken", new ClientAccessTokenParameters());

            if (currentToken != null)
                return currentToken.AccessToken!;

            var disco = await this.httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = this.serviceApiSetting.IdentityBaseUri,
            });

            if (disco.IsError)
                throw disco.Exception!;

            ClientCredentialsTokenRequest clientCredentialTokenRequest = new()
            {
                ClientId = this.clientSetting.WebClient.ClientId,
                ClientSecret = this.clientSetting.WebClient.ClientSecret,
                Address = disco.TokenEndpoint
            };

            var newToken = await this.httpClient.RequestClientCredentialsTokenAsync
                (clientCredentialTokenRequest);

            if (newToken is { IsError: true })
                throw newToken.Exception!;

            await this.clientAccessTokenCache.SetAsync
                ("WebClientToken", newToken.AccessToken!, newToken.ExpiresIn, default!);

            return newToken.AccessToken!;
        }

        public async Task<Response<bool>> LogoutAsync()
        {
            await httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await RevokeRefreshTokenAsync();
            return Response<bool>.Success(200);
        }

        public async Task RevokeRefreshTokenAsync()
        {
            var disco = await this.httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = this.serviceApiSetting.IdentityBaseUri,
                Policy = new DiscoveryPolicy { RequireHttps = false }
            });

            if (disco.IsError)
                throw disco.Exception!;

            var refreshToken = await this.httpContextAccessor.HttpContext!.GetTokenAsync
                (OpenIdConnectParameterNames.RefreshToken);

            TokenRevocationRequest tokenRevocationRequest = new()
            {
                ClientId = this.clientSetting.WebClientForUser.ClientId,
                ClientSecret = this.clientSetting.WebClientForUser.ClientSecret,
                Address = disco.RevocationEndpoint,
                Token = refreshToken!,
                TokenTypeHint = "refresh_token"
            };

            await this.httpClient.RevokeTokenAsync(tokenRevocationRequest);
        }

        public async Task<Response<bool>> SigninAsync(SignInInput signInInput)
        {
            var disco = await this.httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = this.serviceApiSetting.IdentityBaseUri
            });

            if (disco is { IsError: true })
                throw disco.Exception!;

            PasswordTokenRequest passwordTokenRequest = new()
            {
                ClientId = this.clientSetting.WebClientForUser.ClientId,
                ClientSecret = this.clientSetting.WebClientForUser.ClientSecret,
                UserName = signInInput.Email,
                Password = signInInput.Password,
                Address = disco.TokenEndpoint
            };

            var token = await this.httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

            if (token is { IsError: true })
            {
                var responseContent = await token.HttpResponse.Content.ReadAsStringAsync();
                var errorDto = System.Text.Json.JsonSerializer.Deserialize<ErrorDto>
                    (responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Response<bool>.Fail(errorDto!.Errors, 400);
            }

            var userInfoRequest = new UserInfoRequest
            {
                Token = token.AccessToken,
                Address = disco.UserInfoEndpoint
            };

            var userInfo = await this.httpClient.GetUserInfoAsync(userInfoRequest);

            if (userInfo is { IsError: true })
                throw userInfo.Exception!;

            ClaimsIdentity claimsIdentity = new ClaimsIdentity
                (userInfo.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();

            authenticationProperties.StoreTokens(new List<AuthenticationToken>
            {
                new AuthenticationToken{Name=OpenIdConnectParameterNames.AccessToken,Value=token.AccessToken!},
                new AuthenticationToken{Name=OpenIdConnectParameterNames.RefreshToken,Value=token.RefreshToken!},
                new AuthenticationToken{Name=OpenIdConnectParameterNames.ExpiresIn,
                Value=DateTime.Now.AddSeconds(token.ExpiresIn).ToString("o",CultureInfo.InvariantCulture)}
            });

            authenticationProperties.IsPersistent = signInInput.IsRemember;

            await this.httpContextAccessor.HttpContext!.SignInAsync
                (CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

            return Response<bool>.Success(200);
        }

        public async Task<List<string>> SignUpAsync(Core.Models.Input.SignUpInput signUpInput)
        {
            var disco = await this.httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = this.serviceApiSetting.IdentityBaseUri
            });

            if (disco is { IsError: true })
                throw disco.Exception!;

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest()
            {
                ClientId = this.clientSetting.WebClientForUser.ClientId,
                ClientSecret = this.clientSetting.WebClientForUser.ClientSecret,
                Address = disco.TokenEndpoint
            };

            var token = await this.httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

            if (token is { IsError: true })
                throw token.Exception!;

            var stringContent = new StringContent(JsonConvert.SerializeObject
                (signUpInput), Encoding.UTF8, "application/json");

            this.httpClient.SetBearerToken(token.AccessToken!);
            var response = await httpClient.PostAsync("https://localhost:5001/api/auth/signup", stringContent);

            if (response is { IsSuccessStatusCode: false })
            {
                var errors = JsonConvert.DeserializeObject<List<string>>
                    (await response.Content.ReadAsStringAsync());

                return errors!;
            }
            return null;
        }
    }
}
