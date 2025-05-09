using BoardGameReviewsBackend.Business.Repositories;
using BoardGameReviewsBackend.Business.Services;

namespace BoardGameReviewsBackend.Business.Extensions;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBoardGameService, BoardGameService>(); 
        services.AddScoped<IReviewsService, ReviewsService>(); 
        services.AddTransient<IImageService, ImageService>(); 
        services.AddScoped<IUserService, UserService>(); 
        services.AddScoped<ILogService, LogService>(); 
        services.AddScoped<IAdminService, AdminService>(); 
        services.AddHostedService<LogMonitoringService>(); 
    }
}
