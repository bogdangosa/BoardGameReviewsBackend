using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Services;

public interface IUserService
{
    public Task<User> AddUser(User user);

    public List<User> GetAllUsers();
    public User GetUser(int userId);
    
    public User LoginUser(string username, string password);
    
    public Task<bool> ChangePassword(int userId, string oldPassword, string newPassword);
    
    public Task<bool> DeleteUser(int userId);
    public Task<bool> MakeUserAdmin(int userId);
    public List<MonitoredUser> GetMonitoredUsers();
    
    public string GenerateJwtToken(User user);
    public Task<bool> RequestEmailConfirmation(int userId);
    public bool VerifyCode(int userId, string code);
    public (string,DateTime) GenerateEmailVerificationCode();
}
