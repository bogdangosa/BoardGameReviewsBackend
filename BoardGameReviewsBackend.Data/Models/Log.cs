namespace BoardGameReviewsBackend.Data.Models;

public class Log
{
    public int logId { get; set; }
    public string actionPerformed { get; set; }
    public DateTime date { get; set; }
    public int userId { get; set; }
    public User user { get; set; }
}