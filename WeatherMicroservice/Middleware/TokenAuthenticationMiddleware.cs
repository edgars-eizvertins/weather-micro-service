using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WeatherMicroservice.Middleware
{
    public class TokenAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _token;
        private readonly ILogger<TokenAuthenticationMiddleware> _logger;

        public TokenAuthenticationMiddleware(RequestDelegate next, IConfiguration config, ILogger<TokenAuthenticationMiddleware> logger)
        {
            _next = next;
            _token = config["WeatherApiToken"] ?? "";
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"].ToString();
            if (string.IsNullOrEmpty(token) || token != _token)
            {
                _logger.LogWarning("Unauthorized request: missing or invalid token.");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Invalid or missing token.");
                return;
            }
            await _next(context);
        }
    }
}
