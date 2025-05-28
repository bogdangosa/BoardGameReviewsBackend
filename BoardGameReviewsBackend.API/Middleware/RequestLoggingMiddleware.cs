using System.Diagnostics;
using System.Security.Claims;
using BoardGameReviewsBackend.Business.Services;
using BoardGameReviewsBackend.Data;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.API.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceProvider _serviceProvider;
    
    private readonly List<string> _observedPaths = new()
    {
        "/Boardgame/add",
        "/Boardgame/delete",
        "/Boardgame/update",
        "/Reviews/add",
        "/Reviews/delete",
        "/Reviews/update",
        "/User/login",
        "/User/sign-up",
        "/User/delete",
    };

    public RequestLoggingMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
    {
        _next = next;
        _serviceProvider = serviceProvider;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Skip logging for OPTIONS requests
        if (context.Request.Method.Equals("OPTIONS", StringComparison.OrdinalIgnoreCase))
        {
            await _next(context);
            return;
        }
        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
        // Proceed with the request
        // After the request has been handled, log it
        if (_observedPaths.Contains(context.Request.Path.Value, StringComparer.OrdinalIgnoreCase))
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var logService = scope.ServiceProvider.GetRequiredService<ILogService>();
                
                int userId = 1;
                var user = context.User;
                if (user.Identity?.IsAuthenticated == true)
                {
                    var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier); // Adjust claim type as needed
                    if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var parsedId))
                    {
                        userId = parsedId;
                    }
                }
                Console.WriteLine($"UserId: {userId}");
                
                var action = $"{context.Request.Method} {context.Request.Path}";

                var log = new Log
                {
                    actionPerformed = action,
                    date = DateTime.UtcNow,
                    userId = userId
                };
                await logService.AddLog(log);
            }
        }
        await _next(context);
        Debug.WriteLine($"{context.Request.Method} {context.Request.Path}");
    }
}