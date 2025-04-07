using BoardGameReviewsBackend.Business.Models;

namespace BoardGameReviewsBackend.Business.Repositories;

public class BoardgameRepository : IBoardgameRepository
{
    private List<BoardGame> boardGames;

    public BoardgameRepository()
    {
        this.boardGames = new List<BoardGame>();
        boardGames.Add(new BoardGame
            {
                boardgameId = 1,
                Title = "Catan",
                Description = "A game of resource management where players trade and build settlements.",
                Category = "Strategy",
                ReleaseDate = new DateTime(1995, 1, 1),
                nrOfPlayers = 3,
                playTime = 60,
                weight = 4,
                rating = 8
            });
        boardGames.Add(
            new BoardGame
            {
                boardgameId = 2,
                Title = "Ticket to Ride",
                Description = "A railway-themed game where players collect cards to claim railway routes.",
                Category = "Family",
                ReleaseDate = new DateTime(2004, 1, 1),
                nrOfPlayers = 2,
                playTime = 45,
                weight = 3,
                rating = 8
            });
        boardGames.Add(new BoardGame
        {
            boardgameId = 3,
            Title = "Pandemic",
            Description = "A cooperative game where players work together to stop a global virus outbreak.",
            Category = "Cooperative",
            ReleaseDate = new DateTime(2008, 1, 1),
            nrOfPlayers = 2,
            playTime = 45,
            weight = 4,
            rating = 9
        });
    }


    public List<BoardGame> GetAll()
    {
        return boardGames;
    }

    public BoardGame GetById(long boardgameId)
    {
        return boardGames.Find((game => game.boardgameId == boardgameId));
    }

    public bool Add(BoardGame boardgame)
    {
        throw new NotImplementedException();
    }

    public void Update(BoardGame boardgame)
    {
        throw new NotImplementedException();
    }

    public bool Remove(long boardgameId)
    {
        return boardGames.Remove(GetById(boardgameId));
    }
}