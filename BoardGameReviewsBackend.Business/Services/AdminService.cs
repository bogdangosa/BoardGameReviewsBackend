using BoardGameReviewsBackend.Data.Configurations;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Services;

public class AdminService : IAdminService
{
    private readonly IBoardGameService _boardgameService;
    private readonly ILogService _logService;
    
    public AdminService(IBoardGameService boardgameService,ILogService logService)
    {
        _boardgameService = boardgameService;
        _logService = logService;
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
}
