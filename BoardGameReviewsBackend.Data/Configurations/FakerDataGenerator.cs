using BoardGameReviewsBackend.Data.Models;
using Bogus;

namespace BoardGameReviewsBackend.Data.Configurations;

public static class FakerDataGenerator
{
    public static List<Boardgame> GenerateFakeBoardgames(int count = 10)
    {
        Randomizer.Seed = new Random(123);
        var faker = new Faker<Boardgame>()
            .RuleFor(bg => bg.boardgameid, f => f.IndexFaker + 1)
            .RuleFor(bg => bg.Title, f => f.Commerce.ProductName())
            .RuleFor(bg => bg.Description, f => f.Lorem.Sentence(10))
            .RuleFor(bg => bg.Category, f => f.PickRandom(new[] { "Strategy", "Abstract", "Family", "Party", "Cooperative" }))
            .RuleFor(bg => bg.Image, f => f.Image.PicsumUrl(400, 300))
            .RuleFor(bg => bg.ReleaseDate, f => f.Date.Past(10).ToUniversalTime())
            .RuleFor(bg => bg.nrOfPlayers, f => f.Random.Int(1, 8))
            .RuleFor(bg => bg.playTime, f => f.Random.Int(15, 180))
            .RuleFor(bg => bg.weight, f => Math.Round(f.Random.Double(1.0, 5.0), 2));

        return faker.Generate(count);
    }
}
