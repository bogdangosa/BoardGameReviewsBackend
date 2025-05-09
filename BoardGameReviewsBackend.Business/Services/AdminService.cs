using BoardGameReviewsBackend.Data.Configurations;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Services;

public class AdminService : IAdminService
{
    private readonly IBoardGameService _boardgameService;
    private readonly ILogService _logService;
    private readonly IUserService _userService;
    
    public AdminService(IBoardGameService boardgameService,ILogService logService,IUserService userService)
    {
        _boardgameService = boardgameService;
        _logService = logService;
        _userService = userService;
    }
    
    public async Task<List<Boardgame>> GenerateBoardgameData(int numberOfBoardgames)
    {
        List<Boardgame> boardgames = FakerDataGenerator.GenerateFakeBoardgames(numberOfBoardgames);
        foreach (var boardgame in boardgames)
        {
            boardgame.boardgameid=0;
            await _boardgameService.AddBoardgame(boardgame);
        }
        return boardgames;
    }

    public List<Log> GetAllLogs()
    {
        return _logService.GetAllLogs();
    }
    public List<MonitoredUser> GetSuspectUsers()
    {
        return _userService.GetMonitoredUsers();
    }

    public async Task<bool> DeleteAllLogs()
    {
        return await _logService.DeleteAllLogs();
    }
}
