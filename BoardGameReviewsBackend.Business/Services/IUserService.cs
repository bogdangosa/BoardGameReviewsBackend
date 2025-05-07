using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Services;

public interface IUserService
{
    public bool AddUser(User user);
    
    public User LoginUser(string username, string password);
    
    public bool ChangePassword(int userId, string oldPassword, string newPassword);
    
    public bool DeleteUser(int userId);
    
}