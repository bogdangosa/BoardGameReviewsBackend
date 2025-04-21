using BoardGameReviewsBackend.Business;

namespace BoardGameReviewsBackend.API.Requests.Reviews;

public static class ReviewsExtensions
{
    public static Review toModel(this AddReviewRequest request) => 
        new Review
        {
            reviewId = 0,
            userId = request.userId,
            boardgameId = request.boardgameId,
            rating  = request.rating,
            message = request.message,
        };
}
