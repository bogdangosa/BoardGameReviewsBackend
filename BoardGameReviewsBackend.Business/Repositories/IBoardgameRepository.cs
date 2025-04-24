using BoardGameReviewsBackend.Business.Models;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Repositories;

public interface IBoardgameRepository
{
    bool Clear();
    List<Boardgame> GetAllBoardgames();
    Boardgame GetBoardgameById(int boardgameId);
    Task<bool> AddBoardgame(BoardGame boardgame);
    bool Update(BoardGame boardgame);
    Task<bool> DeleteBoardgame(int boardgameId);
}