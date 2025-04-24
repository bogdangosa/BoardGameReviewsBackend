using BoardGameReviewsBackend.Data.Configurations;
using BoardGameReviewsBackend.Data.Models;
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
        
        modelBuilder.Entity<Boardgame>().HasData(
        new Boardgame
        {
            boardgameid = 1,
            Title = "Azul Duel",
            Description = "Decorate a palace ceiling after creating your own pattern.",
            Category = "Abstract",
            Image = "/azul_duel.jpg",
            ReleaseDate = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            nrOfPlayers = 2,
            playTime = 60,
            weight = 2.2
        },
        new Boardgame
        {
            boardgameid = 2,
            Title = "Lost Ruins of Arnak",
            Description = "Explore an island, discover artifacts, and defeat guardians.",
            Category = "Strategy",
            Image = "/lost_ruins_of_arnak.jpg",
            ReleaseDate = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            nrOfPlayers = 1,
            playTime = 120,
            weight = 2.5
        },
        new Boardgame
        {
            boardgameid = 3,
            Title = "Dune Imperium",
            Description = "Influence, intrigue, and combat in the universe of Dune.",
            Category = "Strategy",
            Image = "/dune_imperium.jpg",
            ReleaseDate = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            nrOfPlayers = 1,
            playTime = 120,
            weight = 3.0
        },
        new Boardgame
        {
            boardgameid = 4,
            Title = "Calico",
            Description = "Sew a quilt, collect buttons, attract cats!",
            Category = "Abstract",
            Image = "/calico.jpg",
            ReleaseDate = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            nrOfPlayers = 4,
            playTime = 45,
            weight = 1.8
        },
        new Boardgame
        {
            boardgameid = 5,
            Title = "Pandemic Legacy",
            Description = "Mutating diseases are spreading around the world - can your team save humanity?",
            Category = "Cooperative",
            Image = "/pandemic_legacy.jpg",
            ReleaseDate = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            nrOfPlayers = 2,
            playTime = 60,
            weight = 3.5
        },
        new Boardgame
        {
            boardgameid = 6,
            Title = "The Crew",
            Description = "Complete missions in space in this cooperative trick-taking game.",
            Category = "Cooperative",
            Image = "/the_crew.jpg",
            ReleaseDate = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            nrOfPlayers = 2,
            playTime = 30,
            weight = 2.0
        },
        new Boardgame
        {
            boardgameid = 7,
            Title = "Monopoly",
            Description = "In this competitive real estate market, there's only one possible outcome: Monopoly!",
            Category = "Family",
            Image = "/monopoly.jpg",
            ReleaseDate = new DateTime(1935, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            nrOfPlayers = 4,
            playTime = 90,
            weight = 1.0
        },
        new Boardgame
        {
            boardgameid = 8,
            Title = "Codenames",
            Description = "Give your team clever one-word clues to help them spot their agents in the field.",
            Category = "Party",
            Image = "/codenames.jpg",
            ReleaseDate = new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            nrOfPlayers = 4,
            playTime = 30,
            weight = 1.5
        },
        new Boardgame
        {
            boardgameid = 9,
            Title = "Catan",
            Description = "Collect and trade resources to build up the island of Catan in this modern classic.",
            Category = "Strategy",
            Image = "/catan.jpg",
            ReleaseDate = new DateTime(1995, 4, 15, 0, 0, 0, DateTimeKind.Utc),
            nrOfPlayers = 3,
            playTime = 90,
            weight = 2.0
        }
    );
    }
}
