using BoardGameReviewsBackend.API.Requests.Users;
using BoardGameReviewsBackend.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameReviewsBackend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _usersService;
        private IEmailService _emailService;

        
        public UserController(IUserService usersService, IEmailService emailService)
        {
            _usersService = usersService;
            _emailService = emailService;
        }
        
        [HttpGet("get-all")]
        public IActionResult GetAllUsers()
        {
            return Ok(_usersService.GetAllUsers());
        }
        
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUpUser(SignupRequest request)
        {
            return Ok(await _usersService.AddUser(request.toModel()));
        }
        
        [HttpPost("login")]
        public IActionResult LoginUser(LoginRequest request)
        {
            try
            {
                var userResponse = _usersService.LoginUser(request.username, request.password);
                var token = _usersService.GenerateJwtToken(userResponse);
                return Ok(new { token = token, user = userResponse });
            }
            catch (Exception exception)
            {
                return Unauthorized(exception.Message);
            }
        }
        
        
        [HttpPost("test-email")]
        public async Task<IActionResult> TestEmail([FromQuery] string email)
        {
            await _emailService.SendEmailAsync(email, "Test", "<b>This is a test email!</b>");
            return Ok("Email sent");
        }
        
        [HttpPost("request-email-confirmation")]
        public async Task<IActionResult> RequestEmailConfirmation([FromQuery] int userId)
        {
            return Ok(await _usersService.RequestEmailConfirmation(userId));
        }
        
        [HttpPost("verify-code")]
        public async Task<IActionResult> VerifyCode([FromQuery] int userId, string code)
        {
            return Ok(_usersService.VerifyCode(userId, code));
        }
        
        [Authorize]
        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequest request)
        {
            return Ok(_usersService.ChangePassword(request.userId, request.newPassword, request.oldPassword));
        }
        
        [Authorize]
        [HttpPost("make-admin")]
        public IActionResult MakeUserAdmin([FromQuery] int userId)
        {
            return Ok(_usersService.MakeUserAdmin(userId));
        }
        
        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser([FromQuery] int userId)
        {
            return Ok(await _usersService.DeleteUser(userId));
        }
    }
}
