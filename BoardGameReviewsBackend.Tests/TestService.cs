using System.Diagnostics;
using BoardGameReviewsBackend.Business.Models;
using BoardGameReviewsBackend.Business.Repositories;
using BoardGameReviewsBackend.Business.Services;

namespace BoardGameReviewsBackend.Tests;

public class TestService
{
    private IBoardgameRepository boardgameRepository;
    private IBoardGameService boardgameService;
    [SetUp]
    public void Setup()
    {
        boardgameRepository = new InMemoryBoardgameRepository();
        boardgameRepository.Clear();
        boardgameService = new BoardGameService(boardgameRepository);
    }
    /*
    [Test]
    public void TestBoardgameService_AddBoardgames()
    {
        Assert.That(boardgameService.AddBoardgame(new BoardGame
        {
            Title= "Azul Duel",
            Description= "Decorate a palace ceiling after creating your own pattern.",
            Category= "Strategy",
            nrOfPlayers= 2,
            playTime= 60,
            ReleaseDate = new DateTime(2021,1,1),
            weight= 2,
            rating = 7,
        }), Is.EqualTo(true));
        Assert.That(boardgameService.GetAllBoardgames().Count(),Is.EqualTo(1));
        
        Assert.That(boardgameService.AddBoardgame(new BoardGame
        {
            Title= "Catan",
            Description= "Decorate a palace ceiling after creating your own pattern.",
            Category= "Family",
            nrOfPlayers= 2,
            playTime= 60,
            ReleaseDate = new DateTime(2021,1,1),
            weight= 2,
            rating = 7,
        }), Is.EqualTo(true));
        Assert.That(boardgameService.AddBoardgame(new BoardGame
        {
            Title= "Azul Duel",
            Description= "Decorate a palace ceiling after creating your own pattern.",
            Category= "Abstract",
            nrOfPlayers= 2,
            playTime= 60,
            ReleaseDate = new DateTime(2021,1,1),
            weight= 2,
            rating = 7,
        }), Is.EqualTo(true));
        Assert.That(boardgameService.AddBoardgame(new BoardGame
        {
            Title= "Azul Duel",
            Description= "Decorate a palace ceiling after creating your own pattern.",
            Category= "Abstract",
            nrOfPlayers= 2,
            playTime= 60,
            ReleaseDate = new DateTime(2021,1,1),
            weight= 2,
            rating = 7,
        }), Is.EqualTo(true));
        
        Assert.That(boardgameService.AddBoardgame(new BoardGame
        {
            Title= "Calico",
            Description= "Decorate a palace ceiling after creating your own pattern.",
            Category= "Abstract",
            nrOfPlayers= 2,
            playTime= 60,
            ReleaseDate = new DateTime(2021,1,1),
            weight= 2,
            rating = 7,
        }), Is.EqualTo(true));
        
        Assert.That(boardgameService.GetAllBoardgames().Count(),Is.EqualTo(5));
    }

    [Test]
    public void TestGetFilteredBoardgames()
    {
        TestBoardgameService_AddBoardgames();
        Assert.That(boardgameService.GetAllBoardgames().Count(),Is.EqualTo(5));
        
        Assert.That(boardgameService.GetFilteredBoardgames(category:"Abstract").Count(), Is.EqualTo(3));
        
        Assert.That(boardgameService.GetFilteredBoardgames().Count(), Is.EqualTo(4));
    }
    
    
    [Test]
    public void TestBoardgameService()
    {
        Assert.That(boardgameService.GetAllBoardgames().Count, Is.EqualTo(0));
        
        Assert.That(boardgameService.GetAllBoardgames(), Is.EquivalentTo(new List<BoardGame>()));
        
        Assert.That(boardgameService.AddBoardgame(new BoardGame
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
        
        Assert.That(boardgameService.AddBoardgame(new BoardGame
        {
            Title= "Azul Duel",
            Description= "Decorate a palace ceiling after creating your own pattern.",
            Category= "Abstract",
            nrOfPlayers= 2,
            playTime= 60,
            ReleaseDate = new DateTime(2021,1,1),
            weight= 2,
            rating = 7,
        }), Is.EqualTo(true));
        
        Assert.That(boardgameService.GetAllBoardgames().Count, Is.EqualTo(2));
        
        Assert.That(boardgameService.GetFilteredBoardgames(category:"Abstract").Count(), Is.EqualTo(1));
        
        Assert.That(boardgameService.AddBoardgame(new BoardGame
        {
            Title= "Azul Duel",
            Description= "Decorate a palace ceiling after creating your own pattern.",
            Category= "Abstract",
            nrOfPlayers= 2,
            playTime= 60,
            ReleaseDate = new DateTime(2021,1,1),
            weight= 2,
            rating = 7,
        }), Is.EqualTo(true));
        
        Assert.That(boardgameService.AddBoardgame(new BoardGame
        {
            Title= "Azul Duel",
            Description= "Decorate a palace ceiling after creating your own pattern.",
            Category= "Abstract",
            nrOfPlayers= 2,
            playTime= 60,
            ReleaseDate = new DateTime(2021,1,1),
            weight= 2,
            rating = 7,
        }), Is.EqualTo(true));
        
        Assert.That(boardgameService.GetAllBoardgames().Count, Is.EqualTo(4));
        
        Assert.That(boardgameService.GetFilteredBoardgames(page:2).Count, Is.EqualTo(0));
        
        Debug.WriteLine(boardgameService.GetFilteredBoardgames(page:1,itemsPerPage:2).Count);
        Assert.That(boardgameService.GetFilteredBoardgames(page:1,itemsPerPage:2).Count, Is.EqualTo(2));

    }

    [Test]
    public void TestDeleteBoardgames()
    {
        TestBoardgameService_AddBoardgames();
        Assert.That(boardgameService.DeleteBoardgame(1),Is.EqualTo(true));
        Assert.That(boardgameService.GetAllBoardgames().Count,Is.EqualTo(4));
        Assert.That(boardgameService.DeleteBoardgame(1),Is.EqualTo(false));
        Assert.That(boardgameService.GetAllBoardgames().Count,Is.EqualTo(4));
    }
    */
}