using Microsoft.AspNetCore.Http;

namespace HotelManagementSystem.Library.Generic
{
    public class HeaderValidationMiddleware : IMiddleware
    {
        private readonly string expectedHeaderValue;

        public HeaderValidationMiddleware(string expectedHeaderValue)
        {
            this.expectedHeaderValue = expectedHeaderValue;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string actualHeaderValue = context.Request.Headers["secret"];
            String referer = context.Request.Headers["Referer"];

            if (actualHeaderValue != expectedHeaderValue && !(referer != null && referer.ToLower().Trim().IndexOf("index.html") > -1))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            await next(context);
        }
    }
}
