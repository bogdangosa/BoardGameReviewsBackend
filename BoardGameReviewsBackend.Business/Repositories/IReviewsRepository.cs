using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Repositories;

public interface IReviewsRepository
{
    public Task<bool> AddOrUpdateReview(Review review);
    public Task<bool> AddReview(Review review);
    
    public Review? GetReview(int reviewId);
    
    public List<Review> GetAllReviews();
    public List<Review> GetReviewsByBoardgameId(int boardgameId);
    
    public Task<bool> DeleteReview(int reviewId);
    public Task<bool> UpdateReview(Review review);
    public Review GetReviewByBoardgameIdAndUserId(int boardgameId, int userId);
}
