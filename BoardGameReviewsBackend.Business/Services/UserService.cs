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
    
    public async Task<bool> AddUser(User user)
    {
        return await _userRepository.AddUser(user);
    }

    public List<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }
    
    public User GetUser(int userId)
    {
        return _userRepository.GetUser(userId);
    }

    public User LoginUser(string username, string password)
    {
        return _userRepository.LoginUser(username, password);
    }

    public async Task<bool> ChangePassword(int userId, string oldPassword, string newPassword)
    {
        return await _userRepository.ChangePassword(userId, oldPassword, newPassword);
    }

    public async Task<bool> DeleteUser(int userId)
    {
        return await _userRepository.DeleteUser(userId);
    }

    public async Task<bool> MakeUserAdmin(int userId)
    {
        return await _userRepository.MakeUserAdmin(userId);
    }

    public string GenerateJwtToken(User user)
    {
        throw new NotImplementedException();
    }
}