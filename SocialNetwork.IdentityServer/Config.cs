using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace SocialNetwork.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource(Permission.GraphPermission.resourseGraph){Scopes={Permission.GraphPermission.graphFullpermission}},
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile()
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope(Permission.GraphPermission.graphFullpermission,"Full Access to Graph API"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName=Permission.ClientPermission.SocialNetworkWeb.ClientName,
                    ClientId=Permission.ClientPermission.SocialNetworkWeb.ClientId,
                    ClientSecrets={new Secret(Permission.ClientPermission.SocialNetworkWeb.ClientSecret.Sha256())},
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowOfflineAccess=true,
                    AllowedScopes=
                    {
                        IdentityServerConstants.LocalApi.ScopeName,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        Permission.GraphPermission.graphFullpermission
                    },
                    AccessTokenLifetime=1*60*60,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int) (DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                    RefreshTokenUsage=TokenUsage.ReUse
                }
            };
    }
}