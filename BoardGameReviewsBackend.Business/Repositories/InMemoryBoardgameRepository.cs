using BoardGameReviewsBackend.Business.Models;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.Business.Repositories;

public class InMemoryBoardgameRepository : IBoardgameRepository
{
    private List<Boardgame> boardGames;

    public InMemoryBoardgameRepository()
    {
        this.boardGames = new List<Boardgame>();
        AddDummyData();
    }

    private void AddDummyData()
    {
        AddBoardgame(new BoardGame
            {
                Title = "Catan",
                Description = "A game of resource management where players trade and build settlements.",
                Category = "Strategy",
                Image = "catan.jpg",
                ReleaseDate = new DateTime(1995, 1, 1),
                nrOfPlayers = 3,
                playTime = 60,
                weight = 4,
                rating = 8
            });
        AddBoardgame(
            new BoardGame
            {
                Title = "Ticket to Ride",
                Description = "A railway-themed game where players collect cards to claim railway routes.",
                Category = "Family",
                Image = "default.jpg",
                ReleaseDate = new DateTime(2004, 1, 1),
                nrOfPlayers = 2,
                playTime = 45,
                weight = 3,
                rating = 8
            });
        AddBoardgame(new BoardGame
        {
            Title = "Pandemic",
            Description = "A cooperative game where players work together to stop a global virus outbreak.",
            Category = "Cooperative",
            Image = "default.jpg",
            ReleaseDate = new DateTime(2008, 1, 1),
            nrOfPlayers = 2,
            playTime = 45,
            weight = 4,
            rating = 9
        });
        AddBoardgame(new BoardGame{
            Title= "Azul Duel",
            Description= "Decorate a palace ceiling after creating your own pattern.",
            Category= "Abstract",
            Image = "azul-duel.jpg",
            nrOfPlayers= 2,
            playTime= 60,
            ReleaseDate = new DateTime(2021,1,1),
            weight= 2,
            rating = 7,
        });
        AddBoardgame(new BoardGame{
            Title= "Lost Ruins of Arnak",
            Description= "Explore an island, discover artifacts, and defeat guardians.",
            Category= "Strategy",
            Image = "default.jpg",
            nrOfPlayers= 1,
            playTime= 120,
            ReleaseDate = new DateTime(2020,1,1),
            weight= 2,
            rating = 5
        });
        
        AddBoardgame(new BoardGame
        {
            Title = "Carcassonne",
            Description = "A tile-placement game where players build a medieval landscape.",
            Category = "Strategy",
            Image = "default.jpg",
            nrOfPlayers = 2,
            playTime = 35,
            ReleaseDate = new DateTime(2000, 5, 1),
            weight = 1,
            rating = 6
        });

        AddBoardgame(new BoardGame
        {
            Title = "7 Wonders",
            Description = "Develop your civilization by drafting cards that build cities and wonders.",
            Category = "Strategy",
            Image = "default.jpg",
            nrOfPlayers = 3,
            playTime = 30,
            ReleaseDate = new DateTime(2010, 1, 1),
            weight = 1,
            rating = 8
        });

        AddBoardgame(new BoardGame
        {
            Title = "Dominion",
            Description = "Build your deck and compete to acquire the most victory points.",
            Category = "Strategy",
            Image = "default.jpg",
            nrOfPlayers = 2,
            playTime = 45,
            ReleaseDate = new DateTime(2008, 1, 1),
            weight = 2,
            rating = 9
        });
        
        AddBoardgame(new BoardGame{
            Title = "Brass: Birmingham",
            Description = "Build networks, grow industries, and navigate the world of the Industrial Revolution.",
            Category = "Strategy",
            Image = "default.jpg",
            nrOfPlayers = 2,
            playTime = 60,
            ReleaseDate = new DateTime(2018, 1, 1),
            weight = 3,
            rating = 8,
        });
        
        AddBoardgame(new BoardGame{
            Title = "Pandemic Legacy: Season 1",
            Description = "Mutating diseases are spreading around the world - can your team save humanity?",
            Category = "Cooperative",
            Image = "default.jpg",
            nrOfPlayers = 1,
            playTime = 90,
            ReleaseDate = new DateTime(2015, 1, 1),
            weight = 2,
            rating = 8,
        });
        
        AddBoardgame(new BoardGame{
            Title = "Ark Nova",
            Description = "Plan and build a modern, scientifically managed zoo to support conservation projects.",
            Category = "Strategy",
            Image = "default.jpg",
            nrOfPlayers = 5,
            playTime = 60,
            ReleaseDate = new DateTime(2021, 1, 1),
            weight = 2,
            rating = 8,
        });
        
        AddBoardgame(new BoardGame{
            Title = "Dune: Imperium",
            Description = "Influence, intrigue, and combat in the universe of Dune.",
            Category = "Cooperative",
            Image = "default.jpg",
            nrOfPlayers = 5,
            playTime = 90,
            ReleaseDate = new DateTime(2020, 1, 1),
            weight = 5,
            rating = 8,
        });
        
        AddBoardgame(new BoardGame{
            Title = "Terraforming Mars",
            Description = "Compete with rival CEOs to make Mars habitable and build your corporate empire.",
            Category = "Abstract",
            Image = "default.jpg",
            nrOfPlayers = 4,
            playTime = 90,
            ReleaseDate = new DateTime(2016, 1, 1),
            weight = 5,
            rating = 8,
        });
    }

    public bool Clear()
    {
        boardGames = new List<Boardgame>();
        return true;
    }

    public List<Boardgame> GetAllBoardgames()
    {
        return boardGames;
    }
    
    public Boardgame GetBoardgameById(int boardgameId)
    {
        return boardGames.Find((game => game.boardgameid == boardgameId));
    }

    public async Task<bool> AddBoardgame(BoardGame boardgame)
    {
        boardgame.boardgameId = boardGames.Count + 1;
        //boardGames.Add(boardgame);
        return true;
    }

    public bool Update(BoardGame boardgame)
    {
        int boardgameiIndex = boardGames.FindIndex(game => game.boardgameid == boardgame.boardgameId);
        boardgame.Image = boardGames[boardgameiIndex].Image;
        //boardGames[boardgameiIndex] = boardgame;
        return true;
    }

    public async Task<bool> DeleteBoardgame(int boardgameId)
    {
        return boardGames.Remove(GetBoardgameById(boardgameId));
    }
}