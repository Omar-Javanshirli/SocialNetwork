using SocialNetwork.Web.Core.Models.Dto;
using SocialNetwork.Web.Core.Services;
using System.Net.Http.Json;

namespace SocialNetwork.Web.Service.Services
{
    public class UserServices : IUserServices
    {
        private readonly HttpClient httpClient;

        public UserServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserDto> GetUser()
        {
            return (await this.httpClient.GetFromJsonAsync<UserDto>("/api/user/getuser"))!;
        } 
    }
}
