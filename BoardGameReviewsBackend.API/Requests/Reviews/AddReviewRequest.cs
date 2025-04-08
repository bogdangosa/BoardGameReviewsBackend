namespace BoardGameReviewsBackend.API.Requests.Reviews;

public class AddReviewRequest
{
    public string  userId { get; set; }
    public string  boardgameId { get; set; }
    public long rating { get; set; }
    public string title { get; set; }
    public string comment { get; set; }
}