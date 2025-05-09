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
    
    private readonly List<string> _excludedPaths = new()
    {
        "/Boardgame/is-available",
        "/Admin/get-logs",
        "/swagger/v1/swagger.json",
        "/swagger/index.html",
    };

    public RequestLoggingMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
    {
        _next = next;
        _serviceProvider = serviceProvider;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
        // Proceed with the request
        // After the request has been handled, log it
        if (!_excludedPaths.Contains(context.Request.Path.Value, StringComparer.OrdinalIgnoreCase))
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var logService = scope.ServiceProvider.GetRequiredService<ILogService>();
                var userId = 1;
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