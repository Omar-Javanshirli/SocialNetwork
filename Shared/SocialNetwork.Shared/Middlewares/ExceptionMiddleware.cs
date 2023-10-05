using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using SocialNetwork.Shared.Dtos;

namespace SocialNetwork.Shared.Middlewares
{
    public static class ExceptionMiddleware
    {
        public static void UseExceptionMiddleware(this WebApplication app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    context.Response.StatusCode = 500;

                    var response = Response<string>.Fail(exceptionFeature!.Error.Message, 500);
                    await context.Response.WriteAsJsonAsync(response);
                });
            });
        }
    }
}
