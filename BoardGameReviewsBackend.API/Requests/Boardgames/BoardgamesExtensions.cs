using BoardGameReviewsBackend.Business.Models;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.API.Requests.Boardgames;

public static class BoardgamesExtensions
{
    public static Boardgame toDatabaseModel(this AddBoardgameRequest request,string imageAdress) => 
        new Boardgame
        {
            Title = request.Title,
            Description = request.Description,
            Category = request.Category,
            Image = imageAdress,
            ReleaseDate = request.ReleaseDate,
            nrOfPlayers = request.nrOfPlayers,
            playTime = request.playTime,
            weight  = request.weight,
        };
    public static BoardGame toModel(this AddBoardgameRequest request,string imageAdress) => 
        new BoardGame
        {
            boardgameId = 0,
            Title = request.Title,
            Description = request.Description,
            Category = request.Category,
            Image = imageAdress,
            ReleaseDate = request.ReleaseDate,
            nrOfPlayers = request.nrOfPlayers,
            playTime = request.playTime,
            weight  = request.weight,
            rating  = request.rating,
        };
    public static BoardGame toModel(this UpdateBoardgameRequest request) => 
        new BoardGame
        {
            boardgameId = request.BoardgameId,
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
