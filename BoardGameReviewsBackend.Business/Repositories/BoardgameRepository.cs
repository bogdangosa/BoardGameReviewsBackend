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

    public List<Boardgame> GetAllBoardgames()
    {
        var queryResponse = _dbContext.Boardgames.ToList();
        
        return queryResponse;
    }

    public Boardgame GetBoardgameById(int boardgameId)
    {
        var queryResponse = _dbContext.Boardgames
            .SingleOrDefault(boardgame => boardgame.boardgameid == boardgameId);
        return queryResponse;
    }

    public async Task<bool> AddBoardgame(Boardgame boardgame)
    {
        _dbContext.Boardgames.Add(boardgame);
        
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public bool Update(BoardGame boardgame)
    {
        return false;
    }

    public async Task<bool> DeleteBoardgame(int boardgameId)
    {
        try
        {
            var boardgameToBeRemoved = _dbContext.Boardgames.Find(boardgameId);
            _dbContext.Boardgames.Remove(boardgameToBeRemoved);

            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }

    }
    
}