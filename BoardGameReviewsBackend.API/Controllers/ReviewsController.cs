using BoardGameReviewsBackend.API.Requests.Reviews;
using BoardGameReviewsBackend.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameReviewsBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ControllerBase
    {
        private IReviewsService _reviewsService;

        public ReviewsController(IReviewsService reviewsService)
        {
            _reviewsService = reviewsService;
        }
        
        [HttpGet("get-all")]
        public IActionResult GetAllReviews()
        {
            return Ok(_reviewsService.GetAllReviews());
        }
        
        [HttpGet("get-one")]
        public IActionResult  GetReview([FromQuery] int reviewId)
        {
            return Ok(_reviewsService.GetReview(reviewId));
        }
        
        [HttpGet("get-by-boardgame")]
        public IActionResult  GetReviewsByBoardgame([FromQuery] int boardgameId)
        {
            return Ok(_reviewsService.GetReviewsByBoardgameId(boardgameId));
        }
        
        [HttpGet("get-by-user-and-boardgame")]
        public IActionResult  GetReviewByUserAndBoardgame([FromQuery] int boardgameId,int userId)
        {
            return Ok(_reviewsService.GetReviewByBoardgameIdAndUserId(boardgameId,userId));
        }
        
        [HttpDelete("delete")]
        public async Task<IActionResult>  DeleteReview([FromQuery] int reviewId)
        {
            return Ok(await _reviewsService.DeleteReview(reviewId));
        }
        
        [HttpPost("add")]
        public async Task<IActionResult>  AddReview([FromBody] AddReviewRequest request)
        {
            return Ok(await _reviewsService.AddReview(request.toModel()));
        }
        
        [HttpPatch("update")]
        public IActionResult UpdateReview([FromBody] UpdateReviewRequest request)
        {
            return Ok(_reviewsService.UpdateReview(request.toModel()));
        }
        
    }
}
