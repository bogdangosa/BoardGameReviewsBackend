using BoardGameReviewsBackend.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BoardGameReviewsBackend.Data;

public class BoardgamesDbContext : DbContext
{
    public BoardgamesDbContext(DbContextOptions<BoardgamesDbContext> options) : base(options)
    {
    }

    public DbSet<Models.Boardgame> Boardgames { get; set; }
    public DbSet<Models.Review> Reviews { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BoardgameConfiguration());
        base.OnModelCreating(modelBuilder);

    }
}
