using BoardGameReviewsBackend.Business.Repositories;
using BoardGameReviewsBackend.Business.Services;

namespace BoardGameReviewsBackend.Business.Extensions;

public static class RepositoryExtensions
{
    public static void AddApplicationRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBoardgameRepository, BoardgameRepository>();
        services.AddScoped<IReviewsRepository, ReviewsRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}