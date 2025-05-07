using BoardGameReviewsBackend.Data;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Repositories;

public class LogRepository : ILogRepository
{
    private readonly BoardgamesDbContext _dbContext;

    public LogRepository(BoardgamesDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    
    public async Task<bool> AddLog(Log log)
    {
        _dbContext.Logs.Add(log);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public List<Log> GetAllLogs()
    {
        return _dbContext.Logs.ToList();
    }
}
