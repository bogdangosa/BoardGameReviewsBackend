namespace BoardGameReviewsBackend.Business.Repositories;

public interface IReviewsRepository
{
    public bool AddReview(Review review);
    
    public Review GetReview(long reviewId);
    
    public List<Review> GetAllReviews();
    
    public bool DeleteReview(long reviewId);
}
