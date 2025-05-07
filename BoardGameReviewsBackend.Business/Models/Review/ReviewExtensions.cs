using BoardGameReviewsBackend.Business.Models;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business;

public static class ReviewExtensions
{
    public static ReviewDTO ToReviewDto(this Review review) =>
        new ReviewDTO
        {
            reviewId = review.reviewId,
            boardgameId = review.boardgameId,
            message = review.message,
            rating = review.rating,
            userId = review.userId,
        };
    public static List<ReviewDTO> ToReviewDtos(this List<Review> reviews)
    {
        var reviewDtos = new List<ReviewDTO>();
        foreach (var review in reviews)
        {
            reviewDtos.Add(review.ToReviewDto());
        }

        return reviewDtos;
    }

    public static Review ToReview(this ReviewDTO review)
        => new Review
        {
            reviewId = review.reviewId,
            boardgameId = review.boardgameId,
            rating = review.rating,
            userId = review.userId,
            message = review.message,
        };
}
