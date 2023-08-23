using B._SocialNetwork.Services.Graph.Core.Services;
using B._SocialNetwork.Services.Graph.Core.UnitOfWorks;
using C._SocialNetwork.Services.Graph.Repository;
using D._SocialNetwork.Services.Graph.Service.Services;
using D._SocialNetwork.Services.Graph.Services.Mapping;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Shared.Services;
using System.IdentityModel.Tokens.Jwt;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();

        var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.Authority = configuration["IdentityServerURL"];
            options.Audience = Permission.GraphPermission.resourseGraph;
            options.RequireHttpsMetadata = false;
        });

        services.AddAutoMapper(typeof(MapProfil));
        services.AddMediatR(typeof(D._SocialNetwork.Services.Graph.Services.CQRS.User.Handlers.QueryHandlers.GetAllUserPostsQueryHandler).Assembly);

        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericService<>), typeof(GenericServices<>));
        services.AddScoped<ISharedIdentityService, SharedIdentityService>();

        return services;
    }
}

