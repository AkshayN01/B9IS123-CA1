using HotelManagementSystem.Library.Services.Data.Admin;
using HotelManagementSystem.Library.Services;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.DataAccess;
using HotelManagementSystem.DataAccess.Repositories;
using IdentityServer4.Models;

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
    .AddInMemoryApiScopes(scopes)
    .AddInMemoryClients(clients)
    .AddInMemoryIdentityResources(resources);

builder.Services.AddAuthentication();

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

app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseIdentityServer();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
