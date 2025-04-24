using BoardGameReviewsBackend.Business.Models;

namespace BoardGameReviewsBackend.Business.Services;

public interface IBoardGameService
{
    public Task<bool> AddBoardgame(BoardGame boardGame);
    public BoardgameDetailedResponse GetBoardgame(int boardgameId);
    public List<BoardgameSummaryResponse> GetFilteredBoardgames(int page=1,int itemsPerPage=4,string sortOrder="none", string category="All");
    public List<BoardgameSummaryResponse> GetAllBoardgames();
    public Task<bool> DeleteBoardgame(int boardgameId);
    public bool UpdateBoardgame(BoardGame boardGame);
}
