using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using Serilog.Formatting.Elasticsearch;

namespace SocialNetwork.Shared.Logging.Extensions
{
    public static class Logging
    {
        public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogging =>
            (builderContext, loggerConfiguration) =>
            {
                var enviroment = builderContext.HostingEnvironment;

                loggerConfiguration
                .ReadFrom.Configuration(builderContext.Configuration)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithProperty("Env", enviroment.EnvironmentName)
                .Enrich.WithProperty("AppName", enviroment.ApplicationName);

                var ElasticsearchBaseUrl = builderContext.Configuration.GetSection
                ("Elasticsearch")["BaseUrl"];
                var ElasticsearchUsername = builderContext.Configuration.GetSection
                ("Elasticsearch")["Username"];
                var ElasticsearchPassword = builderContext.Configuration.GetSection
                ("Elasticsearch")["Password"];
                var ElasticsearchIndexName = builderContext.Configuration.GetSection
                ("Elasticsearch")["IndexName"];

                loggerConfiguration.WriteTo.Elasticsearch(new(new Uri(ElasticsearchBaseUrl!))
                {
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = Serilog.Sinks.Elasticsearch.AutoRegisterTemplateVersion.ESv8,
                    IndexFormat = $"{ElasticsearchIndexName}-{enviroment.EnvironmentName}-logs-" + "{0:yyy.MM.dd}",
                    ModifyConnectionSettings = x => x.BasicAuthentication(ElasticsearchUsername, ElasticsearchPassword),
                    CustomDurableFormatter = new ElasticsearchJsonFormatter()
                }); ;
            };
    }
}
