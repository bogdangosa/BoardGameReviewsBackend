using BoardGameReviewsBackend.Data;
using BoardGameReviewsBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGameReviewsBackend.Business.Repositories;

public class ReviewsRepository:IReviewsRepository
{
    private readonly BoardgamesDbContext _dbContext;
    private const int NoReviewsFound = 0;

    public ReviewsRepository(BoardgamesDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<bool> AddOrUpdateReview(Review review)
    {
        var existingReview = GetReview(review.reviewId);
        if (existingReview == null)
            return await AddReview(review);
        else
            return await UpdateReview(review);
    }

    public async Task<bool> AddReview(Review review)
    {
        _dbContext.Reviews.Add(review);
        
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public Review? GetReview(int reviewId)
    {
        var queryResponse = _dbContext.Reviews
            .SingleOrDefault(review => review.reviewId == reviewId);
        return queryResponse;
    }

    public List<Review> GetAllReviews()
    {
        var queryResponse = _dbContext.Reviews.ToList();
        
        return queryResponse;
    }

    public List<Review> GetReviewsByBoardgameId(int boardgameId)
    {
        var reviews = _dbContext.Reviews
            .Where(review => review.boardgameId == boardgameId)
            .ToList();

        if (reviews == null || reviews.Count == NoReviewsFound)
            throw new KeyNotFoundException($"No reviews found for Boardgame with ID {boardgameId}.");

        return reviews;
    }

    public async Task<bool> DeleteReview(int reviewId)
    {
        try
        {
            var reviewToBeRemoved = _dbContext.Reviews.Find(reviewId);
            _dbContext.Reviews.Remove(reviewToBeRemoved);

            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }
    public async Task<bool> UpdateReview(Review review)
    {
        var existingReview = GetReview(review.reviewId);
        if (existingReview == null)
            throw new KeyNotFoundException($"Review with ID {review.reviewId} not found.");

        // Update fields
        existingReview.rating = review.rating;
        existingReview.message = review.message;
        existingReview.userId = review.userId;
        existingReview.boardgameId = review.boardgameId;

        // Save changes asynchronously
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public Review GetReviewByBoardgameIdAndUserId(int boardgameId, int userId)
    {
        var review = _dbContext.Reviews
            .Where(review => review.boardgameId == boardgameId)
            .SingleOrDefault(review => review.userId == userId);
        
        if (review == null)
            return new Review { rating = 0 };
        
        return review;
    }
}
