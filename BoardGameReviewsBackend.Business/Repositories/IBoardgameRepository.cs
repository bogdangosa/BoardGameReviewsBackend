using BoardGameReviewsBackend.Business.Models;

namespace BoardGameReviewsBackend.Business.Repositories;

public interface IBoardgameRepository
{
    List<BoardGame> GetAll();
    BoardGame GetById(long boardgameId);
    bool Add(BoardGame boardgame);
    void Update(BoardGame boardgame);
    bool Remove(long boardgameId);
}