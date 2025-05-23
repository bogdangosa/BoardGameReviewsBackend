namespace BoardGameReviewsBackend.Business.Models;

public class BoardgameSummaryResponse
{
    public int boardgameId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
    public double Rating { get; set; }
}
