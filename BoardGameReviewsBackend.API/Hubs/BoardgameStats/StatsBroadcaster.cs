using BoardGameReviewsBackend.Business.Models.Stats;
using BoardGameReviewsBackend.Business.Repositories;
using BoardGameReviewsBackend.Business.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGameReviewsBackend.API.Hubs.BoardgameStats;

public class StatsBroadcaster: BackgroundService
{
    private readonly IHubContext<BoardgameStatsHub> _hubContext;
    private readonly  IBoardGameService _boardgameService;

    public StatsBroadcaster(IHubContext<BoardgameStatsHub> hubContext, IBoardGameService boardgameService)
    {
        _hubContext = hubContext;
        _boardgameService = boardgameService;
    }

    public async Task BroadcastAll()
    {
        var data = _boardgameService.GetAllBoardgames();

        var boardgamesByCategory = data.GroupBy(bg => bg.Category)
            .Select(g => new ChartDataByCategory
            {
                Category = g.Key,
                Count = g.Count()
            })
            .ToList();
        

        await _hubContext.Clients.All.SendAsync("receivecategorydata", boardgamesByCategory);
        await _hubContext.Clients.All.SendAsync("receivepiechartdata", boardgamesByCategory);
        await _hubContext.Clients.All.SendAsync("ReceiveTopCategoryData", boardgamesByCategory);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await BroadcastAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on bradcast all:"+ex.Message);
            }
            await Task.Delay(2500, stoppingToken); 
        }
    }
}