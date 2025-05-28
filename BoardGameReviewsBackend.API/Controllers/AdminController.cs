using BoardGameReviewsBackend.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameReviewsBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;
        
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        
        [Authorize]
        [HttpGet("get-logs")]
        public IActionResult  GetAllLogs()
        {
            return Ok(_adminService.GetAllLogs());
        }
        
        [Authorize]
        [HttpPost("seed-boardgames")]
        public async Task<IActionResult> SeedBoardGames([FromQuery] int numberOfGames)
        {
            
            return Ok(await _adminService.GenerateBoardgameData(numberOfGames));
        }
        
        [Authorize]
        [HttpGet("get-monitored-users")]
        public IActionResult GetMonitoredUsers()
        {
            return Ok(_adminService.GetSuspectUsers());
        }
        
        [Authorize]
        [HttpDelete("delete-all-logs")]
        public async Task<IActionResult> DeleteAllLogs()
        {
            return Ok(await _adminService.DeleteAllLogs());
        }
    }
}
