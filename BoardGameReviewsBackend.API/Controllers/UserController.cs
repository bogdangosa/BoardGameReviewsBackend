using BoardGameReviewsBackend.API.Requests.Users;
using BoardGameReviewsBackend.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameReviewsBackend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _usersService;
        
        public UserController(IUserService usersService)
        {
            _usersService = usersService;
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
                var response = _usersService.LoginUser(request.username, request.password);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return Unauthorized(exception.Message);
            }
        }
        
        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequest request)
        {
            return Ok(_usersService.ChangePassword(request.userId, request.newPassword, request.oldPassword));
        }
        
        [HttpPost("make-admin")]
        public IActionResult MakeUserAdmin([FromQuery] int userId)
        {
            return Ok(_usersService.MakeUserAdmin(userId));
        }
        
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser([FromQuery] int userId)
        {
            return Ok(await _usersService.DeleteUser(userId));
        }
    }
}
