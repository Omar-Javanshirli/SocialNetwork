using Ocelot.Middleware;
using Ocelot.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile($"configuration.{hostingContext.HostingEnvironment.EnvironmentName.ToLower()}.json").AddEnvironmentVariables();
});

builder.Services.AddAuthentication().AddJwtBearer(Permission.GatewayPermission.GatewayAuthenticationScheme, options =>
{
    options.Authority = builder.Configuration["IdentityServerURL"];
    options.Audience = Permission.GatewayPermission.ResourceGateway;
});

builder.Services.AddOcelot();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

await app.UseOcelot();
app.Run();

