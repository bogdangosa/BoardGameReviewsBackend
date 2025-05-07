using BoardGameReviewsBackend.Business;

namespace BoardGameReviewsBackend.API.Requests.Reviews;

public static class ReviewsExtensions
{
    public static ReviewDTO toModel(this AddReviewRequest request) => 
        new ReviewDTO
        {
            reviewId = request.reviewId,
            userId = request.userId,
            boardgameId = request.boardgameId,
            rating  = request.rating,
            message = request.message,
        };
    
    public static ReviewDTO toModel(this UpdateReviewRequest request) => 
        new ReviewDTO
        {
            reviewId = request.reviewId,
            userId = request.userId,
            boardgameId = request.boardgameId,
            rating  = request.rating,
            message = request.message,
        };
}
