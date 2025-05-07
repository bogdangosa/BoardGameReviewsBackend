using BoardGameReviewsBackend.Business.Models;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Services;

public interface IBoardGameService
{
    public Task<bool> AddBoardgame(Boardgame boardGame);
    public BoardgameDetailedResponse GetBoardgame(int boardgameId);
    public List<BoardgameSummaryResponse> GetFilteredBoardgames(int page=1,int itemsPerPage=4,string sortOrder="none", string category="All");
    public List<BoardgameSummaryResponse> GetAllBoardgames();
    public Task<bool> DeleteBoardgame(int boardgameId);
    public bool UpdateBoardgame(BoardGame boardGame);
}
