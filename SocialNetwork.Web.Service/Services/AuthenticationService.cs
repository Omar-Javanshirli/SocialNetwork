using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using SocialNetwork.Shared.Dtos;
using SocialNetwork.Web.Core.Models.Input;
using SocialNetwork.Web.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor

        public AuthenticationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<TokenResponse> GetAccessTokenByRefreshTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetRefreshTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTokenByClientAsync()
        {
            throw new NotImplementedException();
        }

        public Task RevokeRefreshTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> SigninAsync(SignInInput signInInput)
        {
            throw new NotImplementedException();
        }
    }
}
