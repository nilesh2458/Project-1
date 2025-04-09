using Microsoft.Extensions.Logging;
using System.IO;

namespace UserManagementAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // Logs the HTTP request method and path, and the response status code
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Incoming Request: {Method} {Path}", context.Request.Method, context.Request.Path);

            var originalResponseStream = context.Response.Body;
            using (var memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;

                await _next(context); // Call next middleware

                _logger.LogInformation("Response: {StatusCode}", context.Response.StatusCode);

                await memoryStream.CopyToAsync(originalResponseStream); // Send response to the client
            }
        }
    }
}
