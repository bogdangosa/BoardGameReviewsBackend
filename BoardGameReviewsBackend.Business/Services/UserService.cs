using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BoardGameReviewsBackend.Business.Repositories;
using BoardGameReviewsBackend.Data.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BoardGameReviewsBackend.Business.Services;

public class UserService : IUserService
{
    private readonly Dictionary<string, (string Code, DateTime ExpiryDate)> _emailVerifications = new();
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;
    private readonly JwtSettings _jwtSettings;
    
    public UserService(IUserRepository userRepository,IOptions<JwtSettings> jwtOptions,IEmailService emailService)
    {
        _userRepository = userRepository;
        _emailService = emailService;
        _jwtSettings = jwtOptions.Value;
    }
    
    public async Task<bool> AddUser(User user)
    {
        bool result =  await _userRepository.AddUser(user);
        if(result)
            await _emailService.SendWelcomeEmailAsync(user.email,user.username);
        return result;
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

    public List<MonitoredUser> GetMonitoredUsers()
    {
        return _userRepository.GetMonitoredUsers();
    }

    
    public string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.userId.ToString()),
            new Claim(ClaimTypes.Name, user.username),
            new Claim(ClaimTypes.Role, user.isAdmin ? "Admin" : "User")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<bool> RequestEmailConfirmation(int userId)
    {
        var user  = _userRepository.GetUser(userId);
        var (code, expiryDate) = GenerateEmailVerificationCode();
        
        _emailVerifications[user.email] = (code, expiryDate);
        
        await _emailService.SendConfirmationEmailAsync(user.email, code);
        
        return true;
    }

    public bool VerifyCode(int userId, string code)
    {
        var user  = _userRepository.GetUser(userId);
        
        if (_emailVerifications.TryGetValue(user.email, out var data))
        {
            if (data.Code == code && data.ExpiryDate > DateTime.UtcNow)
            {
                _emailVerifications.Remove(user.email);
                return true;
            }
        }
        return false;
    }

    private const int ConfirmationCodeMin = 100000;
    private const int ConfirmationCodeMax = 999999;
    private const int CodeExpiryMinutes = 10;
    public (string,DateTime) GenerateEmailVerificationCode()
    {
        var code = new Random().Next(ConfirmationCodeMin, ConfirmationCodeMax).ToString();
        var expiryDate = DateTime.UtcNow.AddMinutes(CodeExpiryMinutes);
        return (code, expiryDate);
    }
}
