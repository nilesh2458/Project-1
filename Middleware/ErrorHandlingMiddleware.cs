using Microsoft.Extensions.Logging;

namespace UserManagementAPI.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // Catches unhandled exceptions and returns a standard error message
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Proceed with request
            }
            catch (Exception ex)
            {
                // Log the error and return a generic 500 error
                _logger.LogError(ex, "Unhandled exception");

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var errorResponse = new { error = "Internal server error." };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
