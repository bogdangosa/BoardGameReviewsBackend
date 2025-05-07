namespace BoardGameReviewsBackend.Data.Models;

public class Review
{
    public int reviewId { get; set; }
    public int rating { get; set; }
    public string? message { get; set; }
    public int userId { get; set; }
    public User user { get; set; }
    public int boardgameId { get; set; }
    public Boardgame boardgame { get; set; }
}