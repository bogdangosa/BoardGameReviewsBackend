using BoardGameReviewsBackend.Business.Models;

namespace BoardGameReviewsBackend.Business.Services;

public interface IBoardGameService
{
    public bool AddBoardgame();
    public BoardGame GetBoardgame(long boardgameId);
    public List<BoardGame> GetAllBoardgames();
    public bool DeleteBoardgame(long boardgameId);
}
