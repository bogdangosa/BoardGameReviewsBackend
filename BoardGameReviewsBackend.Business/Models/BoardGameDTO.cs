namespace BoardGameReviewsBackend.Business.Models;

public class BoardGameDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int? nrOfPlayers { get; set; }
    public int? playTime { get; set; }
    public int? weight { get; set; }
    public int? rating { get; set; }
}