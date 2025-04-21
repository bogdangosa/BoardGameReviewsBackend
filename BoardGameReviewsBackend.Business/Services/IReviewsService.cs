namespace BoardGameReviewsBackend.Business.Services;

public interface IReviewsService
{
    public bool AddReview(Review review);
    
    public Review GetReview(long reviewId);
    
    public List<Review> GetAllReviews();
    
    public bool DeleteReview(long reviewId);
}
