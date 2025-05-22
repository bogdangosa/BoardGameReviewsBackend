using BoardGameReviewsBackend.Business.Models;
using BoardGameReviewsBackend.Business.Repositories;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Services;

public class BoardGameService : IBoardGameService
{
    private readonly IBoardgameRepository _boardgameRepository;
    private readonly IReviewsService _reviewsService;
    
    public BoardGameService(IBoardgameRepository boardgameRepository,IReviewsService reviewsService)
    {
        _boardgameRepository = boardgameRepository;
        _reviewsService = reviewsService;
    }
    
    public async Task<bool> AddBoardgame(Boardgame boardgame)
        => await _boardgameRepository.AddBoardgame(boardgame);
    
    public BoardgameDetailedResponse GetBoardgame(int boardgameId)
        => _boardgameRepository.GetBoardgameById(boardgameId);
    
    public List<BoardgameSummaryResponse> GetFilteredBoardgames(int page=1,int itemsPerPage=4,string sortOrder="none", string category="All")
    {
        List<BoardgameSummaryResponse> boardGames = _boardgameRepository.GetBoardgames(page, itemsPerPage,category,sortOrder).ToBoardgameSummaryResponses();;
        if (sortOrder == "Alphabetically")
            boardGames.Sort((boardGame1, boardGame2) => 
                SortAlphabetical(boardGame1, boardGame2));
        else if (sortOrder == "Rating")
            boardGames.Sort((boardGame1, boardGame2) => 
                SortByRating(boardGame1, boardGame2));
        else 
            boardGames.Sort((boardGame1, boardGame2) => 
                SortById(boardGame1, boardGame2));
        return boardGames;
    }

    public List<BoardgameSummaryResponse> GetAllBoardgames()
    {
        return _boardgameRepository.GetAllBoardgames();
    }
    
    public List<BoardgameSummaryResponse> AddRatingToResponses(List<BoardgameSummaryResponse> boardgameResponses)
    {
        foreach (var boardgame in boardgameResponses)
        {
            boardgame.Rating = _reviewsService.GetAverageRatingOfBoardgame(boardgame.boardgameId);
        }
        return boardgameResponses;
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
        return (int)(boardgame2.Rating - boardgame1.Rating);
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