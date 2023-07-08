using Microsoft.AspNetCore.Authentication.Cookies;
using SocialNetwork.Web.Core.Models.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<ClientSetting>(builder.Configuration.GetSection("ClientSetting"));
builder.Services.Configure<ServiceApiSetting>(builder.Configuration.GetSection("ServiceApiSetting"));

builder.Services.AddHttpContextAccessor();
builder.Services.AddAccessTokenManagement();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .()

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
