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
        public IActionResult GetAllBoardgames([FromQuery] GetBoardgamesRequest request)
        {
            int currentPage = request.page ?? 1;
            int itemsPerPage = request.itemsPerPage ?? 4;
            string sortOrder = request.sortOrder ?? "none";
            string category = request.category ?? "all";
            return Ok(_boardgameService.GetAllBoardgames(currentPage,itemsPerPage,sortOrder,category));
        }
        
        [HttpGet("get-one")]
        public IActionResult  GetBoardgame([FromQuery] long boardgameId)
        {
            return Ok(_boardgameService.GetBoardgame(boardgameId));
        }
        
        [HttpPost("add")]
        public IActionResult AddBoardgame([FromBody] AddBoardgameRequest addBoardgameRequest)
        {
            bool addedBoardgame = _boardgameService.AddBoardgame(addBoardgameRequest.toModel());
            
            if (addedBoardgame) 
                return Ok();
            else
                return BadRequest();
        }
        
        [HttpDelete("delete")]
        public IActionResult DeleteBoardgame([FromQuery] DeleteBoardgameRequest request)
        {
            return Ok(_boardgameService.DeleteBoardgame(request.boardgameId));
        }
        
        [HttpPatch("update")]
        public IActionResult UpdateBoardgame([FromBody] UpdateBoardgameRequest request)
        {
            return Ok();
        }
        
    }
}
