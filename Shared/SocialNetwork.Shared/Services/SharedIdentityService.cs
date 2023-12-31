﻿using Microsoft.AspNetCore.Http;
using System;

namespace SocialNetwork.Shared.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public SharedIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId => Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst("sub").Value);
    }
}
