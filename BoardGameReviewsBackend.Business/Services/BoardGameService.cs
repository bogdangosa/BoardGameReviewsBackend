using BoardGameReviewsBackend.Business.Models;
using BoardGameReviewsBackend.Business.Repositories;

namespace BoardGameReviewsBackend.Business.Services;

public class BoardGameService : IBoardGameService
{
    private readonly IBoardgameRepository _boardgameRepository;
    
    public BoardGameService(IBoardgameRepository boardgameRepository)
    {
        _boardgameRepository = boardgameRepository;
    }
    
    public async Task<bool> AddBoardgame(BoardGame boardgame)
    {
        return await _boardgameRepository.AddBoardgame(boardgame);
    }

    public BoardgameDetailedResponse GetBoardgame(int boardgameId)
    {
        return _boardgameRepository.GetBoardgameById(boardgameId).ToBoardgameDetailedResponse();
    }

    public List<BoardgameSummaryResponse> GetFilteredBoardgames(int page=1,int itemsPerPage=4,string sortOrder="none", string category="All")
    {
        List<BoardgameSummaryResponse> boardGames = this.GetAllBoardgames();
        if(category != "All")
            boardGames = boardGames.Where(boardgame => boardgame.Category == category).ToList();
        if (sortOrder == "Alphabetically")
            boardGames.Sort((boardGame1, boardGame2) => 
                SortAlphabetical(boardGame1, boardGame2));
        else if (sortOrder == "Rating")
            boardGames.Sort((boardGame1, boardGame2) => 
                SortByRating(boardGame1, boardGame2));
        else 
            boardGames.Sort((boardGame1, boardGame2) => 
                SortById(boardGame1, boardGame2));
        boardGames = boardGames.Skip((page-1)*itemsPerPage).Take(itemsPerPage).ToList();
        
        return boardGames;
    }

    public List<BoardgameSummaryResponse> GetAllBoardgames()
    {
        return _boardgameRepository.GetAllBoardgames().ToBoardgameSummaryResponses();
    }

    
    public static int SortById(BoardgameSummaryResponse boardgame1, BoardgameSummaryResponse boardgame2)
    {
        return boardgame1.boardgameId - boardgame2.boardgameId;
    }
    public static int SortAlphabetical(BoardgameSummaryResponse boardgame1, BoardgameSummaryResponse boardgame2)
    {
        return boardgame1.Title.CompareTo(boardgame2.Title);
    }

    public static int SortByRating(BoardgameSummaryResponse boardgame1, BoardgameSummaryResponse boardgame2)
    {
        return boardgame2.Rating - boardgame1.Rating;
    }
    

    public async Task<bool> DeleteBoardgame(int boardgameId)
    {
        return await _boardgameRepository.DeleteBoardgame(boardgameId);
    }

    public bool UpdateBoardgame(BoardGame boardGame)
    {
        return _boardgameRepository.Update(boardGame);
    }
}