using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Services;

public interface ILogService
{
    public Task<bool> AddLog(Log log);
    public List<Log> GetAllLogs();   
}