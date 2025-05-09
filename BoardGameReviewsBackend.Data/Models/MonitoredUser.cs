namespace BoardGameReviewsBackend.Data.Models;

public class MonitoredUser
{
        public int monitoredId { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public DateTime monitoredSince { get; set; }
}