using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Services;

public interface IAdminService
{
    public Task<List<Boardgame>> GenerateBoardgameData(int numberOfBoardgames);
    
    public List<Log> GetAllLogs();
    public List<MonitoredUser> GetSuspectUsers();
    public Task<bool> DeleteAllLogs();
}