using BoardGameReviewsBackend.Business.Repositories;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Services;

public class LogService : ILogService
{
    private readonly ILogRepository _logService;
    
    public LogService(ILogRepository logService)
    {
        _logService = logService;
    }
    
    public Task<bool> AddLog(Log log)
    {
        return _logService.AddLog(log);
    }

    public List<Log> GetAllLogs()
    {
        return _logService.GetAllLogs();
    }
}
