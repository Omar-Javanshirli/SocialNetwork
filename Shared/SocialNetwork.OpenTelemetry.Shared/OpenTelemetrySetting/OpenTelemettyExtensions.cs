using MassTransit.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace SocialNetwork.OpenTelemetry.Shared.OpenTelemetrySetting
{
    public static class OpenTelemettyExtensions
    {
        public static void AddOpenTelemetryExt
            (this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<OpenTelemetryConstants>(Configuration.GetSection("OpenTelemetry"));
            var openTelemetryConstants = Configuration.GetSection("OpenTelemetry").Get<OpenTelemetryConstants>();

            ActivitySourceProvider.Source = new System.Diagnostics.ActivitySource(openTelemetryConstants!.ActivitySourceName);

            services.AddOpenTelemetry().WithTracing(options =>
            {
                //for rabbitmq setting
                options.AddSource(openTelemetryConstants!.ActivitySourceName)
                .AddSource(DiagnosticHeaders.DefaultListenerName)
                .ConfigureResource(resource =>
                {
                    resource.AddService(openTelemetryConstants.ServiceName, openTelemetryConstants.ServiceName,
                        openTelemetryConstants.ServiceVersion);
                });

                options.AddAspNetCoreInstrumentation(aspNetCoreOptions =>
                {
                    aspNetCoreOptions.Filter = (context =>
                    {
                        if (!string.IsNullOrEmpty(context.Request.Path.Value))
                            return context.Request.Path.Value.Contains("api", StringComparison.InvariantCulture);

                        return false;
                    });

                    aspNetCoreOptions.RecordException = false;
                });

                options.AddConsoleExporter();
                options.AddOtlpExporter(); //jeager
                options.AddEntityFrameworkCoreInstrumentation(efCoreOptions =>
                {
                    efCoreOptions.SetDbStatementForText = true;
                    efCoreOptions.SetDbStatementForStoredProcedure = true;
                });
                options.AddHttpClientInstrumentation(httpClientOptions =>
                {
                    httpClientOptions.FilterHttpRequestMessage = (request) =>
                    {
                        return !request.RequestUri!.AbsolutePath.Contains("9200", StringComparison.InvariantCulture);
                    };

                    httpClientOptions.EnrichWithHttpRequestMessage = async (activity, request) =>
                    {
                        var requestContent = string.Empty;

                        if (request.Content != null)
                            requestContent = await request.Content.ReadAsStringAsync();

                        activity?.SetTag("http.request.body", requestContent);
                    };

                    httpClientOptions.EnrichWithHttpRequestMessage = async (activity, response) =>
                    {
                        if(response.Content!= null)
                            activity?.SetTag("http.response.body",await response.Content.ReadAsStringAsync());
                    };
                });

                options.AddRedisInstrumentation(redisOptions =>
                {
                    //database ile elaqeli statmentleri detalli sekilde save et.
                    redisOptions.SetVerboseDatabaseStatements = true;
                });
            });
        }

    }
}
