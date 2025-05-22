using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace BoardGameReviewsBackend.Data
{
    public class BoardgamesDbContextFactory : IDesignTimeDbContextFactory<BoardgamesDbContext>
    {
        public BoardgamesDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../BoardGameReviewsBackend.Api"));

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BoardgamesDbContext>();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("BoardGameReviewsBackend.Migrations"));

            return new BoardgamesDbContext(optionsBuilder.Options);
        }
    }
}