using Microsoft.AspNetCore.SignalR;

namespace BoardGameReviewsBackend.API.Hubs.BoardgameStats;

public class BoardgameStatsHub: Hub
{
    public async Task SendCategoryData(List<string> data) =>
        await Clients.All.SendAsync("receivecategorydata", data);

    public async Task SendPieChartData(List<string> data) =>
        await Clients.All.SendAsync("receivepiechartdata", data);

    public async Task SendTopCategoryData(List<string> data) =>
        await Clients.All.SendAsync("ReceiveTopCategoryData", data);
    
}