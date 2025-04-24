using BoardGameReviewsBackend.Data;

namespace BoardGameReviewsBackend.Business.Repositories;

public class ReviewsRepository:IReviewsRepository
{
    private readonly BoardgamesDbContext _dbContext;

    public ReviewsRepository(BoardgamesDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public bool AddReview(Review review)
    {
        throw new NotImplementedException();
    }

    public Review GetReview(int reviewId)
    {
        throw new NotImplementedException();
    }

    public List<Review> GetAllReviews()
    {
        throw new NotImplementedException();
    }

    public List<Review> GetReviewsByBoardgameId(int boardgameId)
    {
        throw new NotImplementedException();
    }

    public bool DeleteReview(int reviewId)
    {
        throw new NotImplementedException();
    }
}
