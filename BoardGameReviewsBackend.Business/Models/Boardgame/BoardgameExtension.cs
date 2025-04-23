using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Models;

public static class BoardgameExtension
{
    public static BoardGame ToBoardGameResponse(this Boardgame boardgame) =>
        new BoardGame
        {
            boardgameId = boardgame.boardgameid,
            Category = boardgame.Category,
            Image = boardgame.Image,
            Description = boardgame.Description,
            nrOfPlayers = boardgame.nrOfPlayers,
            playTime = boardgame.playTime,
            rating = boardgame.rating,
            ReleaseDate = boardgame.ReleaseDate,
            Title = boardgame.Title,
            weight = boardgame.weight,
        };
    
    public static List<BoardGame> ToBoardGameResponses(this List<Boardgame> boardgames)
    {
        var boardgameResponses = new List<BoardGame>();
        foreach (var boardgame in boardgames)
        {
            boardgameResponses.Add(boardgame.ToBoardGameResponse());
        }

        return boardgameResponses;
    }
}