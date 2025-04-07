using BoardGameReviewsBackend.API.Requests.Boardgames;
using BoardGameReviewsBackend.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameReviewsBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardgameController : ControllerBase
    {
        public IBoardGameService _boardgameService;

        public BoardgameController(IBoardGameService boardgameService)
        {
            _boardgameService = boardgameService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAllBoardgames()
        {
            return Ok(_boardgameService.GetAllBoardgames());
        }
        
        [HttpPost("get-one")]
        public IActionResult  GetBoardgame([FromBody] GetBoardgameRequest request)
        {
            return Ok(_boardgameService.GetBoardgame(request.boardgameId));
        }
        
        [HttpPost("add")]
        public IActionResult AddBoardgame([FromBody] AddBoardgameRequest addBoardgameRequest)
        {
            bool addedBoardgame = _boardgameService.AddBoardgame();
            
            if (addedBoardgame) 
                return Ok();
            else
                return BadRequest();
        }
        
        [HttpDelete("delete")]
        public IActionResult DeleteBoardgame([FromBody] DeleteBoardgameRequest request)
        {
            return Ok(_boardgameService.DeleteBoardgame(request.boardgameId));
        }
        
        [HttpPut("update")]
        public IActionResult UpdateBoardgame()
        {
            return Ok();
        }
        
    }
}
