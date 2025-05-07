namespace BoardGameReviewsBackend.Business.Services;

public interface IReviewsService
{
    public Task<bool> AddReview(ReviewDTO reviewDto);
    
    public ReviewDTO GetReview(int reviewId);
    
    public List<ReviewDTO> GetAllReviews();
    
    public List<ReviewDTO> GetReviewsByBoardgameId(int boardgameId);
    
    public Task<bool> DeleteReview(int reviewId);
    public Task<bool> UpdateReview(ReviewDTO reviewDto);
    public int GetAverageRatingOfBoardgame(int boardgameId);
    public ReviewDTO GetReviewByBoardgameIdAndUserId(int boardgameId, int userId);
}
