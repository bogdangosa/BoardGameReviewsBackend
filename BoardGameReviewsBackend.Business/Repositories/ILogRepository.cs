using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Repositories;

public interface ILogRepository
{
    public Task<bool> AddLog(Log log);
    public List<Log> GetAllLogs();   
}