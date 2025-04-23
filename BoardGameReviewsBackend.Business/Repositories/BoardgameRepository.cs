using BoardGameReviewsBackend.Business.Models;
using BoardGameReviewsBackend.Data;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Repositories;

public class BoardgameRepository : IBoardgameRepository
{
    private readonly BoardgamesDbContext _dbContext;

    public BoardgameRepository(BoardgamesDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public bool Clear()
    {
        _dbContext.Boardgames.RemoveRange(_dbContext.Boardgames);
        return true;
    }

    public List<BoardGame> GetAll()
    {
        var queryResponse = _dbContext.Boardgames.ToList();
        return queryResponse.ToBoardGameResponses();
    }

    public BoardGame GetById(int boardgameId)
    {
        var queryResponse = _dbContext.Boardgames
            .SingleOrDefault(boardgame => boardgame.boardgameid == boardgameId);
        return queryResponse.ToBoardGameResponse();
    }

    public async Task<bool> AddBoardgame(BoardGame boardgame)
    {
        
        var newBoardgame = new Data.Models.Boardgame
        {
            Title = boardgame.Title,
            Category = boardgame.Category,
            Description = boardgame.Description,
            Image = boardgame.Image,
            ReleaseDate = boardgame.ReleaseDate
        };
        _dbContext.Boardgames.Add(newBoardgame);
        
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public bool Update(BoardGame boardgame)
    {
        return false;
    }

    public bool DeleteBoardgame(int boardgameId)
    {
        return false;
    }
    
}