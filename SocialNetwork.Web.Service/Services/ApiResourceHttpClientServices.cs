using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using SocialNetwork.IdentityServer.Core.Models.Input;
using SocialNetwork.Web.Core.Models.Settings;
using SocialNetwork.Web.Core.Services;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace SocialNetwork.Web.Service.Services
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
            this.client = new HttpClient();
            this.clientSetting = clientSetting.Value;
            this.serviceApiSetting = serviceApiSetting.Value;
        }

        public async Task<HttpClient> GetHttpClientAsync()
        {
            var accessToken = await this.contextAccessor.HttpContext!.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            this.client.SetBearerToken(accessToken!);
            return client;
        }

      
    }
}
