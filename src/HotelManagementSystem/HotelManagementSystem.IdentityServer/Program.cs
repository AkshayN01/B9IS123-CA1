using HotelManagementSystem.Contracts.Generic;
using HotelManagementSystem.DataAccess;
using HotelManagementSystem.DataAccess.Repositories;
using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library.Services.Data;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetSection("AdminConnectionString").Value ?? "";
builder.Services.AddDbContext<AdminDbContext>(options => options.UseMySQL(connectionString));
builder.Services.AddScoped<IUnitOfWork, AdminUnitOfWork>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<HotelBranchService>();

var clients = builder.Configuration.GetSection("Clients").Get<List<Client>>();
var scopes = builder.Configuration.GetSection("ApiScopes").Get<List<ApiScope>>();
var resources = builder.Configuration.GetSection("IdentityResources").Get<List<IdentityResource>>();
builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryIdentityResources(resources)
    .AddInMemoryApiScopes(scopes)
    .AddInMemoryClients(clients);

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

app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
