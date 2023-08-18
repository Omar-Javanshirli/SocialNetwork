using B._SocialNetwork.Services.Graph.Core.Services;
using B._SocialNetwork.Services.Graph.Core.UnitOfWorks;
using C._SocialNetwork.Services.Graph.Repository;
using D._SocialNetwork.Services.Graph.Service.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(D._SocialNetwork.Services.Graph.Services.CQRS.User.Handlers.QueryHandlers.GetAllUserPostsQueryHandler).Assembly);
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericService<>), typeof(GenericServices<>));

        return services;
    }
}

