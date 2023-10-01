using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using SocialNetwork.WEB.Core.Models.Settings;
using SocialNetwork.WEB.Core.Services.Authentication;

namespace SocialNetwork.WEB.Service.Services.Authentication
{
    public class ApiResourceHttpClientServices : IApiResourceHttpClientService
    {
        private readonly IHttpContextAccessor contextAccessor;
        private HttpClient client;
        private readonly ClientSetting clientSetting;
        private readonly ServiceApiSetting serviceApiSetting;

        public ApiResourceHttpClientServices(IHttpContextAccessor contextAccessor,
            IOptions<ClientSetting> clientSetting, IOptions<ServiceApiSetting> serviceApiSetting)
        {
            this.contextAccessor = contextAccessor;
            client = new HttpClient();
            this.clientSetting = clientSetting.Value;
            this.serviceApiSetting = serviceApiSetting.Value;
        }

        public async Task<HttpClient> GetHttpClientAsync()
        {
            var accessToken = await contextAccessor.HttpContext!.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            client.SetBearerToken(accessToken!);
            return client;
        }
    }
}
