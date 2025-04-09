using BoardGameReviewsBackend.Business.Models;

namespace BoardGameReviewsBackend.Business.Repositories;

public class BoardgameRepository : IBoardgameRepository
{
    private List<BoardGame> boardGames;

    public BoardgameRepository()
    {
        this.boardGames = new List<BoardGame>();
        AddDummyData();
    }

    private void AddDummyData()
    {
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
        
        boardGames.Add(new BoardGame
        {
            boardgameId = 9,
            Title = "Carcassonne",
            Description = "A tile-placement game where players build a medieval landscape.",
            Category = "Strategy",
            nrOfPlayers = 2,
            playTime = 35,
            ReleaseDate = new DateTime(2000, 5, 1),
            weight = 1,
            rating = 6
        });

        boardGames.Add(new BoardGame
        {
            boardgameId = 10,
            Title = "7 Wonders",
            Description = "Develop your civilization by drafting cards that build cities and wonders.",
            Category = "Strategy",
            nrOfPlayers = 3,
            playTime = 30,
            ReleaseDate = new DateTime(2010, 1, 1),
            weight = 1,
            rating = 8
        });

        boardGames.Add(new BoardGame
        {
            boardgameId = 11,
            Title = "Dominion",
            Description = "Build your deck and compete to acquire the most victory points.",
            Category = "Strategy",
            nrOfPlayers = 2,
            playTime = 45,
            ReleaseDate = new DateTime(2008, 1, 1),
            weight = 2,
            rating = 9
        });
        
        boardGames.Add(new BoardGame{
            boardgameId = 1,
            Title = "Brass: Birmingham",
            Description = "Build networks, grow industries, and navigate the world of the Industrial Revolution.",
            Category = "Strategy",
            nrOfPlayers = 2,
            playTime = 60,
            ReleaseDate = new DateTime(2018, 1, 1),
            weight = 3,
            rating = 8,
        });
        
        boardGames.Add(new BoardGame{
            boardgameId = 2,
            Title = "Pandemic Legacy: Season 1",
            Description = "Mutating diseases are spreading around the world - can your team save humanity?",
            Category = "Cooperative",
            nrOfPlayers = 1,
            playTime = 90,
            ReleaseDate = new DateTime(2015, 1, 1),
            weight = 2,
            rating = 8,
        });
        
        boardGames.Add(new BoardGame{
            boardgameId = 3,
            Title = "Ark Nova",
            Description = "Plan and build a modern, scientifically managed zoo to support conservation projects.",
            Category = "Strategy",
            nrOfPlayers = 5,
            playTime = 60,
            ReleaseDate = new DateTime(2021, 1, 1),
            weight = 2,
            rating = 8,
        });
        
        boardGames.Add(new BoardGame{
            boardgameId = 6,
            Title = "Dune: Imperium",
            Description = "Influence, intrigue, and combat in the universe of Dune.",
            Category = "Cooperative",
            nrOfPlayers = 5,
            playTime = 90,
            ReleaseDate = new DateTime(2020, 1, 1),
            weight = 5,
            rating = 8,
        });
        
        boardGames.Add(new BoardGame{
            boardgameId = 7,
            Title = "Terraforming Mars",
            Description = "Compete with rival CEOs to make Mars habitable and build your corporate empire.",
            Category = "Abstract",
            nrOfPlayers = 4,
            playTime = 90,
            ReleaseDate = new DateTime(2016, 1, 1),
            weight = 5,
            rating = 8,
        });
    }

    public bool Clear()
    {
        boardGames = new List<BoardGame>();
        return true;
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

    public bool Update(BoardGame boardgame)
    {
        int boardgameiIndex = boardGames.FindIndex(game => game.boardgameId == boardgame.boardgameId);
        boardGames[boardgameiIndex] = boardgame;
        return true;
    }

    public bool Remove(long boardgameId)
    {
        return boardGames.Remove(GetById(boardgameId));
    }
}