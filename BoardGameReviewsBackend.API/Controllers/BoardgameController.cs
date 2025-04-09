using System.Diagnostics;
using BoardGameReviewsBackend.API.Requests.Boardgames;
using BoardGameReviewsBackend.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameReviewsBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardgameController : ControllerBase
    {
        private IBoardGameService _boardgameService;
        private IImageService _imageService;

        public BoardgameController(IBoardGameService boardgameService,IImageService imageService)
        {
            _boardgameService = boardgameService;
            _imageService = imageService;
        }
        
        
        [HttpGet("get-all")]
        public IActionResult GetAllBoardgames()
        {
            return Ok(_boardgameService.GetAllBoardgames());
        }
        

        [HttpGet("get-filtered")]
        public IActionResult GetFilteredBoardgames([FromQuery] GetBoardgamesRequest request)
        {
            int currentPage = request.page ?? 1;
            int itemsPerPage = request.itemsPerPage ?? 4;
            string sortOrder = request.sortOrder ?? "none";
            string category = request.category ?? "All";
            return Ok(_boardgameService.GetFilteredBoardgames(currentPage,itemsPerPage,sortOrder,category));
        }
        
        [HttpGet("get-one")]
        public IActionResult  GetBoardgame([FromQuery] long boardgameId)
        {
            return Ok(_boardgameService.GetBoardgame(boardgameId));
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> AddBoardgame([FromForm] AddBoardgameRequest addBoardgameRequest)
        {
            string[] allowedExtensions = [".jpg", ".jpeg", ".png", ".gif"];
            string imageAdress = await _imageService.SaveImage(addBoardgameRequest.ImageFile,allowedExtensions);
            Debug.WriteLine(imageAdress);
            
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
            return Ok(_boardgameService.UpdateBoardgame(request.toModel()));
        }
        
    }
}
