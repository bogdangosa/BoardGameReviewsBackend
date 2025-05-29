using BoardGameReviewsBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BoardGameReviewsBackend.API
{
    public class BoardgamesDbContextFactory : IDesignTimeDbContextFactory<BoardgamesDbContext>
    {
        public BoardgamesDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BoardgamesDbContext>();
            optionsBuilder.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("BoardGameReviewsBackend.Migrations"));

            return new BoardgamesDbContext(optionsBuilder.Options);
        }
    }
}
