using B._SocialNetwork.Services.Graph.Core.Services;
using B._SocialNetwork.Services.Graph.Core.UnitOfWorks;
using C._SocialNetwork.Services.Graph.Repository;
using D._SocialNetwork.Services.Graph.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var requireAuthorizePolicy=new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.Authority = Configuration["IdentityServerURL"];
            options.Audience = "resource_basket";
            options.RequireHttpsMetadata = false;
        });

        services.AddMediatR(typeof(D._SocialNetwork.Services.Graph.Services.CQRS.User.Handlers.QueryHandlers.GetAllUserPostsQueryHandler).Assembly);
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericService<>), typeof(GenericServices<>));

        return services;
    }
}

