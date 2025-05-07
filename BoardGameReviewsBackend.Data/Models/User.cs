namespace BoardGameReviewsBackend.Data.Models;

public class User
{
    public int userId { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public bool isAdmin { get; set; }
    public ICollection<Review> Reviews { get; } = new List<Review>();
    public ICollection<Log> Logs { get; } = new List<Log>();
}