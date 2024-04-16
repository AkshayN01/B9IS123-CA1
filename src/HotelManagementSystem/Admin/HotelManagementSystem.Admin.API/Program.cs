using HotelManagementSystem.DataAccess;
using HotelManagementSystem.DataAccess.Repositories;
using HotelManagementSystem.Library.Services.Data.Admin;
using HotelManagementSystem.Library.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using HotelManagementSystem.Library;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetSection("AdminConnectionString").Value ?? "";
builder.Services.AddDbContext<AdminDbContext>(options => options.UseMySQL(connectionString));
builder.Services.AddScoped<IAdminUnitOfWork, AdminUnitOfWork>();
builder.Services.AddTransient<HotelBranchService>();
builder.Services.AddTransient<ManagementService>();
builder.Services.AddTransient<UserService>();

var authorizer = builder.Configuration.GetSection("Identity").GetSection("Authorizer").Value;
var clientId = builder.Configuration.GetSection("Identity").GetSection("clientId").Value;
var clientName = builder.Configuration.GetSection("Identity").GetSection("clientName").Value;
var scope = builder.Configuration.GetSection("Identity").GetSection("scope").Value;
var secret = builder.Configuration.GetSection("Identity").GetSection("secret").Value;

builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer("Bearer", options =>
{
    options.Authority = "https://localhost:7016";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", scope);
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotel Management Admin API", Version = "v1" });

    // Define the OAuth2 scheme
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            ClientCredentials = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri($"{authorizer}/connect/authorize"),
                TokenUrl = new Uri($"{authorizer}/connect/token"),
                Scopes = new Dictionary<string, string> { { scope, clientName } }
            }
        }
    });

    // Define the security requirements
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                },
                new[] { scope }
            }
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel Management Admin API V1");

        // Configure OAuth2
        c.OAuthClientId(clientId);
        c.OAuthClientSecret(secret);
        c.OAuthAppName(clientName);
        c.OAuthUsePkce();
    });
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

//app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
