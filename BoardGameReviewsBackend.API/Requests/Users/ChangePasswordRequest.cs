namespace BoardGameReviewsBackend.API.Requests.Users;

public class ChangePasswordRequest
{
    public int userId { get; set; }
    public string oldPassword { get; set; }
    public string newPassword { get; set; }
}