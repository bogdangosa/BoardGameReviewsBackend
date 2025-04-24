using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Models;

public static class BoardgameExtension
{
    public static BoardgameSummaryResponse ToBoardgameSummaryResponse(this Boardgame boardgame) =>
        new BoardgameSummaryResponse
        {
            boardgameId = boardgame.boardgameid,
            Title = boardgame.Title,
            Description = boardgame.Description,
            Category = boardgame.Category,
            Image = boardgame.Image,
            Rating = 0,
        };
    
    public static List<BoardgameSummaryResponse> ToBoardgameSummaryResponses(this List<Boardgame> boardgames)
    {
        var boardgameResponses = new List<BoardgameSummaryResponse>();
        foreach (var boardgame in boardgames)
        {
            boardgameResponses.Add(boardgame.ToBoardgameSummaryResponse());
        }

        return boardgameResponses;
    }
    
    public static BoardgameDetailedResponse ToBoardgameDetailedResponse(this Boardgame boardgame) =>
        new BoardgameDetailedResponse
        {
            boardgameId = boardgame.boardgameid,
            Title = boardgame.Title,
            Description = boardgame.Description,
            Category = boardgame.Category,
            Image = boardgame.Image,
            Rating = 0,
            ReleaseDate = boardgame.ReleaseDate,
            NumberOfPlayers = boardgame.nrOfPlayers,
            PlayTime = boardgame.playTime,
            Weight = boardgame.weight,
        };
    
}
