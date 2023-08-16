using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using SocialNetwork.Shared.Exceptions;
using IAuthenticationService = SocialNetwork.Web.Core.Services.IAuthenticationService;

namespace SocialNetwork.Web.Service.Handler
{
    public class ResourceOwnerPasswordTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IAuthenticationService authenticationService;

        public ResourceOwnerPasswordTokenHandler(IHttpContextAccessor contextAccessor, IAuthenticationService authenticationService)
        {
            this.contextAccessor = contextAccessor;
            this.authenticationService = authenticationService;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await contextAccessor.HttpContext!.GetTokenAsync
                (OpenIdConnectParameterNames.AccessToken);

            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await base.SendAsync(request, cancellationToken);

            if (response is { StatusCode: System.Net.HttpStatusCode.Unauthorized })
            {
                var tokenResponse = await authenticationService.GetAccessTokenByRefreshTokenAsync();

                if (tokenResponse != null)
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue
                        ("Bearer", tokenResponse.AccessToken);

                    response = await base.SendAsync(request, cancellationToken);
                }
            }

            if (response is { StatusCode: System.Net.HttpStatusCode.Unauthorized })
                throw new UnAuthorizeException();

            return response;
        }
    }
}
