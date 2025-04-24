namespace BoardGameReviewsBackend.Business.Services;

public interface IReviewsService
{
    public bool AddReview(Review review);
    
    public Review GetReview(int reviewId);
    
    public List<Review> GetAllReviews();
    
    public List<Review> GetReviewsByBoardgameId(int boardgameId);
    
    public bool DeleteReview(int reviewId);
}
