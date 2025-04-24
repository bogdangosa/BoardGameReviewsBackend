using BoardGameReviewsBackend.Business.Repositories;

namespace BoardGameReviewsBackend.Business.Services;

public class ReviewsService:IReviewsService
{
    private readonly IReviewsRepository _reviewsRepository;
    
    public ReviewsService(IReviewsRepository reviewsRepository)
    {
        _reviewsRepository = _reviewsRepository;
    }
    
    public bool AddReview(Review review)
    {
        return _reviewsRepository.AddReview(review);
    }

    public Review GetReview(int reviewId)
    {
        return _reviewsRepository.GetReview(reviewId);
    }

    public List<Review> GetAllReviews()
    {
        return _reviewsRepository.GetAllReviews();
    }

    public List<Review> GetReviewsByBoardgameId(int boardgameId)
    {
        return _reviewsRepository.GetReviewsByBoardgameId(boardgameId);
    }

    public bool DeleteReview(int reviewId)
    {
        return _reviewsRepository.DeleteReview(reviewId);
    }
}