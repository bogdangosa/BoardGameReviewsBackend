namespace BoardGameReviewsBackend.Business;

public class Review
{
    public int reviewId { get; set; }
    public int boardgameId { get; set; }
    public int userId { get; set; }
    public int rating { get; set; }
    public string? message { get; set; }
}
