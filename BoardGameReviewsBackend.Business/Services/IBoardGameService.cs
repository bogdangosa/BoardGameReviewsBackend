using BoardGameReviewsBackend.Business.Models;

namespace BoardGameReviewsBackend.Business.Services;

public interface IBoardGameService
{
    public Task<bool> AddBoardgame(BoardGame boardGame);
    public BoardGame GetBoardgame(int boardgameId);
    public List<BoardGame> GetFilteredBoardgames(int page=1,int itemsPerPage=4,string sortOrder="none", string category="All");
    public List<BoardGame> GetAllBoardgames();
    public bool DeleteBoardgame(int boardgameId);
    public bool UpdateBoardgame(BoardGame boardGame);
}
