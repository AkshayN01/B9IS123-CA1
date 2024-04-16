using HotelManagementSystem.Library.Services.Data.Admin;
using HotelManagementSystem.Library.Services;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.DataAccess;
using HotelManagementSystem.DataAccess.Repositories;
using IdentityServer4.Models;
using HotelManagementSystem.IdentityServer;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using IdentityServerHost.Quickstart.UI;
using HotelManagementSystem.Contracts.Generic;
using IdentityServer4.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetSection("AdminConnectionString").Value ?? "";
builder.Services.AddDbContext<AdminDbContext>(options => options.UseMySQL(connectionString));
builder.Services.AddScoped<IAdminUnitOfWork, AdminUnitOfWork>();
builder.Services.AddTransient<HotelBranchService>();
builder.Services.AddTransient<UserService>();

var clients = builder.Configuration.GetSection("Clients").Get<List<IdentityServer4.Models.Client>>();
var scopes = builder.Configuration.GetSection("ApiScopes").Get<List<ApiScope>>();
var resources = builder.Configuration.GetSection("IdentityResources").Get<List<IdentityResource>>();
builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddTestUsers(TestUsers.Users)
    .AddInMemoryApiScopes(scopes)
    .AddInMemoryClients(clients)
    .AddInMemoryIdentityResources(resources);
builder.Services.AddTransient<IProfileService, UserProfileService>();
builder.Services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();

builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.Use(async (ctx, next) =>
//{
//    ctx.SetIdentityServerOrigin("https://localhost:7016");
//    await next();
//});
//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
app.UseIdentityServer();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
