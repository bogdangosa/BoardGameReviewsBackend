using BoardGameReviewsBackend.Data;
using BoardGameReviewsBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGameReviewsBackend.Business.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BoardgamesDbContext _dbContext;

    public UserRepository(BoardgamesDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public List<User> GetAllUsers()
    {
        var result = _dbContext.Users.ToList();
        return result;
    }

    public User GetUser(int userId)
    {
        var result = _dbContext.Users
            .SingleOrDefault(user=>user.userId==userId);
        if(result == null)
            throw new Exception("User not found");
        
        return result;
    }

    public async Task<User> AddUser(User user)
    {
        _dbContext.Users.Add(user);
        
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public User LoginUser(string username, string password)
    {
        var user = _dbContext.Users
            .SingleOrDefault(user=>user.username == username);
        if(user == null)
            throw new Exception("username doesn't exist");
        if (user.password != password)
            throw new Exception("password doesn't match");
        return user;
    }

    public async Task<bool> ChangePassword(int userId, string oldPassword, string newPassword)
    {
        var user = _dbContext.Users
            .SingleOrDefault(user => user.userId==userId);
        if(user == null)
            throw new Exception("username doesn't exist");
        if (user.password != oldPassword)
            throw new Exception("password doesn't match");
        user.password = newPassword;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUser(int userId)
    {
        var user = GetUser(userId);
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> MakeUserAdmin(int userId)
    {
        var user = GetUser(userId);  
        user.isAdmin = true;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddUserToMonitoredUsers(int userId)
    {
        var existingUser = await _dbContext.MonitoredUsers.FirstOrDefaultAsync(m => m.userId == userId);
        if (existingUser == null)
        {
            _dbContext.MonitoredUsers.Add(new MonitoredUser { userId = userId, monitoredSince = DateTime.UtcNow });
        }
        return true;
    }

    public List<MonitoredUser> GetMonitoredUsers()
    {
        return _dbContext.MonitoredUsers
            .Include(mu => mu.user)
            .Select(mu => new MonitoredUser
            {
                monitoredId = mu.monitoredId,
                userId = mu.userId,
                monitoredSince = mu.monitoredSince,
                user = new User
                {
                    userId = mu.user.userId,
                    username = mu.user.username,
                }
            })
            .ToList();
    }
}
