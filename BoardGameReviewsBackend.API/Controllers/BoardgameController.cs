using System.Diagnostics;
using BoardGameReviewsBackend.API.Requests.Boardgames;
using BoardGameReviewsBackend.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameReviewsBackend.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class BoardgameController : ControllerBase
    {
        private IBoardGameService _boardgameService;
        private IImageService _imageService;
        private const int DefaultCurrentPage= 1;
        private const int DefaultPageSize = 4;

        public BoardgameController(IBoardGameService boardgameService,IImageService imageService)
        {
            _boardgameService = boardgameService;
            _imageService = imageService;
        }
        
        [HttpGet("is-available")]
        public IActionResult IsApiAvailable()
        {
            return Ok(true);
        }
        
        [Authorize]
        [HttpGet("get-all")]
        public IActionResult GetAllBoardgames()
        {
            return Ok(_boardgameService.GetAllBoardgames());
        }
        

        [HttpGet("get-filtered")]
        public IActionResult GetFilteredBoardgames([FromQuery] GetBoardgamesRequest request)
        {
            int currentPage = request.page ?? DefaultCurrentPage;
            int itemsPerPage = request.itemsPerPage ?? DefaultPageSize;
            string sortOrder = request.sortOrder ?? "none";
            string category = request.category ?? "All";
            return Ok(_boardgameService.GetFilteredBoardgames(currentPage,itemsPerPage,sortOrder,category));
        }
        
        [HttpGet("get-one")]
        public IActionResult  GetBoardgame([FromQuery] int boardgameId)
        {
            return Ok(_boardgameService.GetBoardgame(boardgameId));
        }
        
        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddBoardgame([FromForm] AddBoardgameRequest addBoardgameRequest)
        {
            string[] allowedExtensions = [".jpg", ".jpeg", ".png", ".gif"];
            string imageAdress = await _imageService.SaveImage(addBoardgameRequest.ImageFile,allowedExtensions);
            Debug.WriteLine(imageAdress);
            
            bool addedBoardgame = await _boardgameService.AddBoardgame(addBoardgameRequest.toDatabaseModel(imageAdress));
            
            if (addedBoardgame) 
                return Ok(addedBoardgame);
            else
                return BadRequest();
        }
        
        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBoardgame([FromQuery] DeleteBoardgameRequest request)
        {
            return Ok(await _boardgameService.DeleteBoardgame(request.boardgameId));
        }
        
        [Authorize]
        [HttpPatch("update")]
        public IActionResult UpdateBoardgame([FromBody] UpdateBoardgameRequest request)
        {
            return Ok(_boardgameService.UpdateBoardgame(request.toModel()));
        }
        
    }
}
