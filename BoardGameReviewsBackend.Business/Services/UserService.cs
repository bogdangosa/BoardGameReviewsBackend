using BoardGameReviewsBackend.Business.Repositories;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public bool AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public User LoginUser(string username, string password)
    {
        throw new NotImplementedException();
    }

    public bool ChangePassword(int userId, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public bool DeleteUser(int userId)
    {
        throw new NotImplementedException();
    }
}