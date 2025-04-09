using BoardGameReviewsBackend.Business.Repositories;
using BoardGameReviewsBackend.Business.Services;

namespace BoardGameReviewsBackend.Business;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBoardGameService, BoardGameService>(); 
        services.AddTransient<IImageService, ImageService>(); 
    }
}