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

    public BoardGame GetBoardgame(int boardgameId)
    {
        return _boardgameRepository.GetById(boardgameId);
    }

    public List<BoardGame> GetFilteredBoardgames(int page=1,int itemsPerPage=4,string sortOrder="none", string category="All")
    {
        List<BoardGame> boardGames = _boardgameRepository.GetAll();
        if(category != "All")
            boardGames = boardGames.Where(boardgame => boardgame.Category == category).ToList();
        if (sortOrder == "Alphabetically")
            boardGames.Sort((boardGame1, boardGame2) => sortAlphabetical(boardGame1, boardGame2));
        else if (sortOrder == "Rating")
            boardGames.Sort((boardGame1, boardGame2) => sortByRating(boardGame1, boardGame2));
        else 
            boardGames.Sort((boardGame1, boardGame2) => sortById(boardGame1, boardGame2));
        boardGames = boardGames.Skip((page-1)*itemsPerPage).Take(itemsPerPage).ToList();
        return boardGames;
    }

    public List<BoardGame> GetAllBoardgames()
    {
        return _boardgameRepository.GetAll();
    }

    
    public static int sortById(BoardGame boardgame1, BoardGame boardgame2)
    {
        return boardgame1.boardgameId - boardgame2.boardgameId;
    }
    public static int sortAlphabetical(BoardGame boardgame1, BoardGame boardgame2)
    {
        return boardgame1.Title.CompareTo(boardgame2.Title);
    }

    public static int sortByRating(BoardGame boardgame1, BoardGame boardgame2)
    {
        return (boardgame2.rating ?? 0) - (boardgame1.rating ?? 0);
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