namespace BoardGameReviewsBackend.Business.Repositories;

public class ReviewsRepository:IReviewsRepository
{
    private List<Review> reviews;

    public ReviewsRepository()
    {
        this.reviews = new List<Review>();
        AddDummyData();
    }

    private void AddDummyData()
    {
        
    }

    public bool AddReview(Review review)
    {
        throw new NotImplementedException();
    }

    public Review GetReview(long reviewId)
    {
        throw new NotImplementedException();
    }

    public List<Review> GetAllReviews()
    {
        throw new NotImplementedException();
    }

    public bool DeleteReview(long reviewId)
    {
        throw new NotImplementedException();
    }
}
