using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using SocialNetwork.Web.Core.Services;

namespace SocialNetwork.Web.Service.Services
{
    public class ApiResourceHttpClientServices : IApiResourceHttpClientService
    {
        private readonly IHttpContextAccessor contextAccessor;
        private HttpClient client;

        public ApiResourceHttpClientServices(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
            this.client = new HttpClient();
        }

        public async Task<HttpClient> GetHttpClientAsync()
        {
            var accessToken = await this.contextAccessor.HttpContext!.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            this.client.SetBearerToken(accessToken!);
            return client;
        } 
    }
}
