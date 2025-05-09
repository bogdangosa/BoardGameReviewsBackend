using System.Diagnostics;
using BoardGameReviewsBackend.Data;
using BoardGameReviewsBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGameReviewsBackend.Business.Services;


public class LogMonitoringService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly TimeSpan _monitoringInterval = TimeSpan.FromSeconds(30);

    public LogMonitoringService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await MonitorLogs();
            await Task.Delay(_monitoringInterval, stoppingToken);
        }
    }

    private async Task MonitorLogs()
    {
        Debug.WriteLine("Monitoring logs");
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BoardgamesDbContext>();

        // Define suspicious activity criteria
        var suspiciousThreshold = 10; 
        var timeWindow = DateTime.UtcNow.AddMinutes(-1);

        var suspiciousUsers = dbContext.Logs
            .Where(log => log.date >= timeWindow)
            .GroupBy(log => log.userId)
            .Where(group => group.Count() >= suspiciousThreshold)
            .Select(group => group.Key)
            .ToList();

        if (suspiciousUsers.Any())
        {
            foreach (var userId in suspiciousUsers)
            {
                await AddToMonitoredUsers(dbContext, userId);
            }
            await dbContext.SaveChangesAsync();
        }
    }

    private async Task AddToMonitoredUsers(BoardgamesDbContext dbContext, int userId)
    {
        var existingUser = await dbContext.MonitoredUsers.FirstOrDefaultAsync(m => m.userId == userId);
        if (existingUser == null)
        {
            dbContext.MonitoredUsers.Add(new MonitoredUser { userId = userId, monitoredSince = DateTime.UtcNow });
        }
    }
}