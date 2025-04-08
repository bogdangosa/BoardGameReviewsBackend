using BoardGameReviewsBackend.Business.Models;

namespace BoardGameReviewsBackend.Business.Services;

public interface IBoardGameService
{
    public bool AddBoardgame(BoardGame boardGame);
    public BoardGame GetBoardgame(long boardgameId);
    public List<BoardGame> GetAllBoardgames(int page=1,int itemsPerPage=4,string sortOrder="none", string category="all");
    public bool DeleteBoardgame(long boardgameId);
}
