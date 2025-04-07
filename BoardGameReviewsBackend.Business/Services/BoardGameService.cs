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
    
    public bool AddBoardgame()
    {
        return true;
    }

    public BoardGame GetBoardgame(long boardgameId)
    {
        return _boardgameRepository.GetById(boardgameId);
    }

    public List<BoardGame> GetAllBoardgames()
    {
        return _boardgameRepository.GetAll();
    }

    public bool DeleteBoardgame(long boardgameId)
    {
        return _boardgameRepository.Remove(boardgameId);
    }
}