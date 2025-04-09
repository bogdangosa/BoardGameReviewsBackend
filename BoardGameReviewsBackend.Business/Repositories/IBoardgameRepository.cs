using BoardGameReviewsBackend.Business.Models;

namespace BoardGameReviewsBackend.Business.Repositories;

public interface IBoardgameRepository
{
    bool Clear();
    List<BoardGame> GetAll();
    BoardGame GetById(long boardgameId);
    bool Add(BoardGame boardgame);
    bool Update(BoardGame boardgame);
    bool Remove(long boardgameId);
}