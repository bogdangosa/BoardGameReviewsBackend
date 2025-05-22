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

    public List<BoardgameSummaryResponse> GetAllBoardgames()
    {
        var queryResponse = _dbContext.Boardgames
            .Select(bg => new BoardgameSummaryResponse
            {
                boardgameId = bg.boardgameid,
                Description = bg.Description,
                Category = bg.Category,
                Image = bg.Image,
                Title = bg.Title,
                Rating = _dbContext.Reviews
                    .Where(r => r.boardgameId == bg.boardgameid)
                    .Average(r => (double?)r.rating) ?? 0.0
            })
            .ToList();
        return queryResponse;
    }

    public List<Boardgame> GetBoardgames(int pageNumber=1,int itemsPerPage=4,string category="All",string sortOrder="none")
    {
        var queryResponse = _dbContext.Boardgames
            .Where(boardgame => boardgame.Category == category || category == "All")
            .OrderBy(boardgame => boardgame.boardgameid)
            .Skip((pageNumber - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToList();
        
        return queryResponse;
    }

    public BoardgameDetailedResponse GetBoardgameById(int boardgameId)
    {
        var queryResponse = _dbContext.Boardgames
            .Where(boardgame => boardgame.boardgameid == boardgameId)
            .Select(boardgame=>new BoardgameDetailedResponse
            {
                boardgameId = boardgame.boardgameid,
                Title = boardgame.Title,
                Description = boardgame.Description,
                Category = boardgame.Category,
                Image = boardgame.Image,
                NumberOfPlayers = boardgame.nrOfPlayers,
                PlayTime = boardgame.playTime,
                ReleaseDate = boardgame.ReleaseDate,
                Weight = boardgame.weight,
                Rating = _dbContext.Reviews
                    .Where(review => review.boardgameId == boardgame.boardgameid)
                    .Average(review => (double?)review.rating) ?? 0.0
            })
            .SingleOrDefault();
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