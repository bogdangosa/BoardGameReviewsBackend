using BoardGameReviewsBackend.Business.Services;
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
        
        [HttpGet("get-logs")]
        public IActionResult  GetAllLogs()
        {
            return Ok(_adminService.GetAllLogs());
        }
        
        [HttpPost("seed-boardgames")]
        public async Task<IActionResult> SeedBoardGames([FromQuery] int numberOfGames)
        {
            
            return Ok(await _adminService.GenerateBoardgameData(numberOfGames));
        }
        
        [HttpGet("get-monitored-users")]
        public IActionResult GetMonitoredUsers()
        {
            return Ok(_adminService.GetSuspectUsers());
        }
        
        [HttpDelete("delete-all-logs")]
        public async Task<IActionResult> DeleteAllLogs()
        {
            return Ok(_adminService.DeleteAllLogs());
        }
    }
}
