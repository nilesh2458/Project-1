using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserManagementAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add essential services to the container
builder.Services.AddLogging();
builder.Services.AddControllers();

var app = builder.Build();

// Add middleware in the order they should be executed
app.UseMiddleware<ErrorHandlingMiddleware>(); // Handle unexpected errors
app.UseMiddleware<AuthenticationMiddleware>(); // Secure endpoints with token-based auth
app.UseMiddleware<LoggingMiddleware>(); // Log requests and responses

app.UseHttpsRedirection();
app.UseAuthorization();

// Set up API routes
app.MapControllers();

app.Run();
