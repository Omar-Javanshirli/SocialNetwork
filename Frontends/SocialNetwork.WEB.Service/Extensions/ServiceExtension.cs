using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Web.Core.Models.Settings;
using SocialNetwork.Web.Core.Services;
using SocialNetwork.Web.Service.Handler;
using SocialNetwork.Web.Service.Services;
using SocialNetwork.WEB.Core.Services.Authentication;
using SocialNetwork.WEB.Service.Services.Authentication;

namespace SocialNetwork.Web.Service.Extensions
{
    public static class ServiceExtension
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration Configuration)
        {
            var serviceApiSettings = Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSetting>();

            services.AddHttpClient<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IApiResourceHttpClientService,ApiResourceHttpClientServices>();
            services.AddScoped<ResourceOwnerPasswordTokenHandler>();
            

            services.AddHttpClient<IUserServices, UserServices>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings!.IdentityBaseUri);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
        }
    }
}
