using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Services;

public interface IAdminService
{
    public Task<List<Boardgame>> GenerateBoardgameData(int numberOfBoardgames);
}