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
        
        [HttpDelete("delete")]
        public IActionResult  DeleteReview([FromQuery] int reviewId)
        {
            return Ok(_reviewsService.GetReview(reviewId));
        }
        
        [HttpPost("add")]
        public IActionResult  AddReview([FromBody] AddReviewRequest request)
        {
            return Ok(_reviewsService.AddReview(request.toModel()));
        }
        
    }
}
