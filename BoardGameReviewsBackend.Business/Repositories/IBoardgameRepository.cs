using BoardGameReviewsBackend.Business.Models;

namespace BoardGameReviewsBackend.Business.Repositories;

public interface IBoardgameRepository
{
    bool Clear();
    List<BoardGame> GetAll();
    BoardGame GetById(int boardgameId);
    bool AddBoardgame(BoardGame boardgame);
    bool Update(BoardGame boardgame);
    bool DeleteBoardgame(int boardgameId);
}