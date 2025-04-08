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
    
    public bool AddBoardgame(BoardGame boardgame)
    {
        return _boardgameRepository.Add(boardgame);
    }

    public BoardGame GetBoardgame(long boardgameId)
    {
        return _boardgameRepository.GetById(boardgameId);
    }

    public List<BoardGame> GetAllBoardgames(int page=1,int itemsPerPage=4,string sortOrder="none", string category="all")
    {
        List<BoardGame> boardGames = _boardgameRepository.GetAll();
        if(category != "all")
            boardGames = boardGames.Where(boardgame => boardgame.Category == category).ToList();
        if (sortOrder == "alphabetical")
            boardGames.Sort((boardGame1, boardGame2) => sortAlphabetical(boardGame1, boardGame2));
        boardGames = boardGames.Skip((page-1)*itemsPerPage).Take(itemsPerPage).ToList();
        return boardGames;
    }

    public static int sortAlphabetical(BoardGame boardgame1, BoardGame boardgame2)
    {
        return boardgame1.Title.CompareTo(boardgame2.Title);
    }

    public bool DeleteBoardgame(long boardgameId)
    {
        return _boardgameRepository.Remove(boardgameId);
    }
}