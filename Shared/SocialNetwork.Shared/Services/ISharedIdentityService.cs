using System;

namespace SocialNetwork.Shared.Services
{
    public interface ISharedIdentityService
    {
        public Guid GetUserId {  get; }
    }
}
