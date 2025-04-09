using Microsoft.Extensions.Logging;

namespace UserManagementAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthenticationMiddleware> _logger;

        public AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // Validates the token in the Authorization header
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token) || !ValidateToken(token))
            {
                _logger.LogWarning("Unauthorized request attempt.");
                context.Response.StatusCode = 401; // Unauthorized
                context.Response.ContentType = "application/json";
                var errorResponse = new { error = "Unauthorized" };
                await context.Response.WriteAsJsonAsync(errorResponse);
                return;
            }

            await _next(context); // Proceed if the token is valid
        }

        private bool ValidateToken(string token)
        {
            // Simulating token validation. In real life, you'd use JWT or another mechanism.
            return token == "valid-token"; // Placeholder token validation
        }
    }
}
