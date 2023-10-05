﻿using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using System.Diagnostics;

namespace SocialNetwork.Shared.Middlewares
{
    public class RequestAndResponseActivityMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RecyclableMemoryStreamManager _memoryStreamManager;

        public RequestAndResponseActivityMiddleware(RequestDelegate next)
        {
            _next = next;
            _memoryStreamManager = new RecyclableMemoryStreamManager();
        }


        public async Task InvokeAsync(HttpContext context)
        {
            await AddRequestBodyContentToActivityTag(context);
            await AddResponseBodyContentToActivityTag(context);
        }

        private async Task AddRequestBodyContentToActivityTag(HttpContext context)
        {
            context.Request.EnableBuffering();
            var requestBodyStreamReader = new StreamReader(context.Request.Body);
            var requestBodyContent = await requestBodyStreamReader.ReadToEndAsync();
            Activity.Current?.SetTag("http.request.body", requestBodyContent);
            context.Request.Body.Position = 0;
        }

        private async Task AddResponseBodyContentToActivityTag(HttpContext context)
        {
            var originalResponse = context.Response.Body;
            await using var responseBodyMemoryStream = _memoryStreamManager.GetStream();

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
