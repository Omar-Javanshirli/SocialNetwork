
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

        }

        private async Task AddRequestBodyContentToActivityTag(HttpContext context)
        {
            context.Request.EnableBuffering();
            var requestBodyStreamReader = new StreamReader(context.Request.Body);
            var requestBodyContent = await requestBodyStreamReader.ReadToEndAsync();

            Activity.Current?.SetTag("http.request.body", requestBodyContent);
            context.Response.Body.Position = 0;
        }
    }
}
