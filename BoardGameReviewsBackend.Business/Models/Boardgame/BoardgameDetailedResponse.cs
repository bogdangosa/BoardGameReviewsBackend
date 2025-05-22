namespace BoardGameReviewsBackend.Business.Models;

public class BoardgameDetailedResponse
{
    public int boardgameId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int? NumberOfPlayers { get; set; }
    public int? PlayTime { get; set; }
    public double? Weight { get; set; }
    public double Rating { get; set; }   
}