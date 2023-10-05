
using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace SocialNetwork.Shared.Middlewares
{
    public class RequestAndResponseActivityMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RecyclableMemoryStreamManager _memoryStreadManager;

        public RequestAndResponseActivityMiddleware(RequestDelegate next)
        {
            _next = next;
            _memoryStreadManager = new RecyclableMemoryStreamManager();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await AddRequestBodyContentToActivityTagAsync(context);
            await AddResponseBodyContentToActivityTagAsync(context);
        }

        private async Task AddRequestBodyContentToActivityTagAsync(HttpContext context)
        {
            context.Request.EnableBuffering();
            var requestBodyStreamReader = new StreamReader(context.Request.Body);
            var requestBodyContent = await requestBodyStreamReader.ReadToEndAsync();

            Activity.Current?.SetTag("http.request.body", requestBodyContent);
            context.Response.Body.Position = 0;
        }

        private async Task AddResponseBodyContentToActivityTagAsync(HttpContext context)
        {
            var originalResponse = context.Response.Body;

            await using var responseBodyMemoryStream = _memoryStreadManager.GetStream();
            context.Response.Body = responseBodyMemoryStream;

            await _next(context);
            responseBodyMemoryStream.Position = 0;

            var responseBodyStreamReader = new StreamReader(responseBodyMemoryStream);
            var responseBodyContent = await responseBodyStreamReader.ReadToEndAsync();

            Activity.Current?.SetTag("http.response.body", responseBodyContent);
            responseBodyMemoryStream.Position = 0;

            await responseBodyMemoryStream.CopyToAsync(originalResponse);
        }
    }
}
