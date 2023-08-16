namespace SocialNetwork.Web.Core.Services
{
    public interface IApiResourceHttpClientService
    {
        Task<HttpClient> GetHttpClientAsync();
    }
}
