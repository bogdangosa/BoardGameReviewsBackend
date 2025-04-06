using BoardGameReviewsBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameReviewsBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardgameController : ControllerBase
    {
        private readonly ILogger<BoardgameController> _logger;

        public BoardgameController(ILogger<BoardgameController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "getBoardgame")]
        public IEnumerable<BoardGame> Get()
        {
            return new BoardGame[]{};
        }
    }
}