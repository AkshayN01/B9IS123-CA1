using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using static IdentityModel.ClaimComparer;

namespace HotelManagementSystem.IdentityServer
{
    public class CustomCookieAuthenticationHandler : CookieAuthenticationHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomCookieAuthenticationHandler(IOptionsMonitor<CookieAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IHttpContextAccessor httpContextAccessor)
            : base(options, logger, encoder, clock)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleSignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
        {
            var cookieBuilder = new CookieBuilder
            {
                Name = Options.Cookie.Name,
                Domain = Options.Cookie.Domain,
                Path = Options.Cookie.Path,
                SameSite = Options.Cookie.SameSite,
                HttpOnly = Options.Cookie.HttpOnly,
                SecurePolicy = CookieSecurePolicy.Always, // Set Secure attribute for cookies
                IsEssential = Options.Cookie.IsEssential
            };

            // Get the HttpContext from IHttpContextAccessor
            var httpContext = _httpContextAccessor.HttpContext;

            // Configure the cookie options in the context of the HttpContext
            httpContext.Response.Cookies.Append(cookieBuilder.Name, cookieBuilder.Name, cookieBuilder.Build(httpContext));

            return base.HandleSignInAsync(user, properties);
        }
    }


}
