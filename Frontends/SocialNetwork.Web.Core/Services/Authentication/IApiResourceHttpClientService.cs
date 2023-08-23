namespace SocialNetwork.WEB.Core.Services.Authentication
{
    public interface IApiResourceHttpClientService
    {
        Task<HttpClient> GetHttpClientAsync();
    }
}
