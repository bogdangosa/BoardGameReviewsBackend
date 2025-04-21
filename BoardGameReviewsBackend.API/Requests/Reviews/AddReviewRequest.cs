namespace BoardGameReviewsBackend.API.Requests.Reviews;

public class AddReviewRequest
{
    public int  userId { get; set; }
    public int  boardgameId { get; set; }
    public int rating { get; set; }
    public string message { get; set; }
}