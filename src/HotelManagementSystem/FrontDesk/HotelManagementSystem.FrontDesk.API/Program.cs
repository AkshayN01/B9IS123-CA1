using HotelManagementSystem.Library.Services.Data.Admin;
using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.DataAccess;
using HotelManagementSystem.DataAccess.Repositories;
using HotelManagementSystem.FrontDesk.DataAccess;
using HotelManagementSystem.Library.Services.Data.FrontDesk;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var adminConnectionString = builder.Configuration.GetSection("AdminConnectionString").Value ?? "";
builder.Services.AddDbContext<AdminDbContext>(options => options.UseMySQL(adminConnectionString));
builder.Services.AddScoped<IAdminUnitOfWork, AdminUnitOfWork>();
builder.Services.AddTransient<HotelBranchService>();
builder.Services.AddTransient<UserService>();

var frontDeskConnectionString = builder.Configuration.GetSection("FrontDeskConnectionString").Value ?? "";
builder.Services.AddDbContext<FrontDeskDbContext>(options => options.UseMySQL(frontDeskConnectionString));
builder.Services.AddScoped<IFrontDeskUnitOfWork, FrontDeskUnitOfWork>();
builder.Services.AddTransient<BookingService>();
builder.Services.AddTransient<RoomService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
