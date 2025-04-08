using BoardGameReviewsBackend.Business.Models;

namespace BoardGameReviewsBackend.API.Requests.Boardgames;

public static class BoardgamesExtensions
{
    public static BoardGame toModel(this AddBoardgameRequest request) => 
        new BoardGame
        {
            boardgameId = 0,
            Title = request.Title,
            Description = request.Description,
            Category = request.Category,
            ReleaseDate = request.ReleaseDate,
            nrOfPlayers = request.nrOfPlayers,
            playTime = request.playTime,
            weight  = request.weight,
            rating  = request.rating,
        };

}
