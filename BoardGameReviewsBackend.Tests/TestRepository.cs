using BoardGameReviewsBackend.Business.Models;
using BoardGameReviewsBackend.Business.Repositories;
using BoardGameReviewsBackend.Business.Services;

namespace BoardGameReviewsBackend.Tests;

public class TestRepository
{
    private IBoardgameRepository boardgameRepository;
    [SetUp]
    public void Setup()
    {
        boardgameRepository = new InMemoryBoardgameRepository();
        boardgameRepository.Clear();
    }
    
    
    [Test]
    public void Repository_ShouldBeEmpty()
    {
        Assert.IsEmpty(boardgameRepository.GetAllBoardgames());
    }
/*
    [Test]
    public void Repository_AddBoardGame()
    {
        var result = boardgameRepository.AddBoardgame(new BoardGame
        {
            Title = "Catan",
            Description = "A game of resource management.",
            Category = "Strategy",
            ReleaseDate = new DateTime(1995, 1, 1),
            nrOfPlayers = 3,
            playTime = 60,
            weight = 4,
            rating = 8
        });

        Assert.IsTrue(result);
        Assert.That(boardgameRepository.GetAll().Count(), Is.EqualTo(1));
    
    }

    [Test]
    public void TestBoardgameRepository()
    {
        boardgameRepository.Clear();
        Assert.IsEmpty(boardgameRepository.GetAll());

        Assert.That(boardgameRepository.AddBoardgame(new BoardGame
        {
            Title = "Catan",
            Description = "A game of resource management where players trade and build settlements.",
            Category = "Strategy",
            ReleaseDate = new DateTime(1995, 1, 1),
            nrOfPlayers = 3,
            playTime = 60,
            weight = 4,
            rating = 8
        }), Is.EqualTo(true));
        Assert.That(boardgameRepository.GetAll().Count(), Is.EqualTo(1));
        
        
        Assert.That(boardgameRepository.GetById(1).Title, Is.EqualTo("Catan"));
        
        Assert.That(boardgameRepository.GetById(100), Is.Null);
        
        Assert.That(boardgameRepository.AddBoardgame(new BoardGame
           {
                Title = "Dominion",
                Description = "Build your deck and compete to acquire the most victory points.",
                Category = "Strategy",
                nrOfPlayers = 2,
                playTime = 45,
                ReleaseDate = new DateTime(2008, 1, 1),
                weight = 2,
                rating = 9
            }), Is.EqualTo(true));
        
        Assert.That(boardgameRepository.GetAll().Count(), Is.EqualTo(2));
        
        Assert.That(boardgameRepository.DeleteBoardgame(100), Is.EqualTo(false));
        
        Assert.That(boardgameRepository.GetAll().Count(), Is.EqualTo(2));
        
        Assert.That(boardgameRepository.DeleteBoardgame(2), Is.EqualTo(true));
        
        Assert.That(boardgameRepository.GetAll().Count(), Is.EqualTo(1));
        
        Assert.That(boardgameRepository.Update(new BoardGame{
            boardgameId = 1,
            Title = "Dominion",
            Description = "Build your deck and compete to acquire the most victory points.",
            Category = "Strategy",
            nrOfPlayers = 2,
            playTime = 45,
            ReleaseDate = new DateTime(2008, 1, 1),
            weight = 2,
            rating = 9
        }), Is.EqualTo(true));
        
        Assert.That(boardgameRepository.GetAll().Count(), Is.EqualTo(1));
        
        Assert.That(boardgameRepository.GetAll()[0].Title, Is.EqualTo("Dominion"));
        Assert.That(boardgameRepository.GetAll()[0].Category, Is.EqualTo("Strategy"));
        
    }
    
    */
}