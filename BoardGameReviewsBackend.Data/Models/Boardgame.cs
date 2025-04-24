namespace BoardGameReviewsBackend.Data.Models;

public class Boardgame
{
    public int boardgameid { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Category { get; set; }
    
    public string Image { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    
    public int? nrOfPlayers { get; set; }
    
    public int? playTime { get; set; }
    
    public int? weight { get; set; }
    
    public ICollection<Review> Reviews { get; } = new List<Review>();
    
}
