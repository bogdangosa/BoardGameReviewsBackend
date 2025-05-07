using BoardGameReviewsBackend.Business.Repositories;

namespace BoardGameReviewsBackend.Business.Services;

public class ReviewsService:IReviewsService
{
    private readonly IReviewsRepository _reviewsRepository;
    private const int NoRating = 0;
    
    public ReviewsService(IReviewsRepository reviewsRepository)
    {
        _reviewsRepository = reviewsRepository;
    }
    
    public async Task<bool> AddReview(ReviewDTO review)
    {
        return await _reviewsRepository.AddOrUpdateReview(review.ToReview());
    }

    public ReviewDTO GetReview(int reviewId)
    {
        return _reviewsRepository.GetReview(reviewId).ToReviewDto();
    }

    public List<ReviewDTO> GetAllReviews()
    {
        return _reviewsRepository.GetAllReviews().ToReviewDtos();
    }

    public List<ReviewDTO> GetReviewsByBoardgameId(int boardgameId)
    {
        return _reviewsRepository.GetReviewsByBoardgameId(boardgameId).ToReviewDtos();
    }

    public async Task<bool> DeleteReview(int reviewId)
    {
        return await _reviewsRepository.DeleteReview(reviewId);
    }

    public async Task<bool> UpdateReview(ReviewDTO reviewDto)
    {
        return await _reviewsRepository.UpdateReview(reviewDto.ToReview());
    }

    public int GetAverageRatingOfBoardgame(int boardgameId)
    {
        int rating = NoRating;
        List<ReviewDTO> reviews;
        try
        {
            reviews = GetReviewsByBoardgameId(boardgameId);
        }
        catch (Exception exception)
        {
            return NoRating;
        }
        foreach (var review in reviews)
        {
            rating += review.rating;
        }
        return rating/reviews.Count;
    }

    public ReviewDTO GetReviewByBoardgameIdAndUserId(int boardgameId, int userId)
    {
        return _reviewsRepository.GetReviewByBoardgameIdAndUserId(boardgameId, userId).ToReviewDto();
    }
}
