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
        boardGames.Add(new BoardGame{
            boardgameId = 4,
            Title= "Azul Duel",
            Description= "Decorate a palace ceiling after creating your own pattern.",
            Category= "Abstract",
            nrOfPlayers= 2,
            playTime= 60,
            ReleaseDate = new DateTime(2021,1,1),
            weight= 2,
            rating = 7,
        });
        boardGames.Add(new BoardGame{
            boardgameId = 5,
            Title= "Lost Ruins of Arnak",
            Description= "Explore an island, discover artifacts, and defeat guardians.",
            Category= "Strategy",
            nrOfPlayers= 1,
            playTime= 120,
            ReleaseDate = new DateTime(2020,1,1),
            weight= 2,
            rating = 5
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
        boardgame.boardgameId = boardGames.Count + 1;
        boardGames.Add(boardgame);
        return true;
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