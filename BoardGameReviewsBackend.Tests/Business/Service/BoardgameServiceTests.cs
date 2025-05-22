using BoardGameReviewsBackend.Business.Repositories;
using BoardGameReviewsBackend.Business.Services;
using Moq;

namespace BoardGameReviewsBackend.Tests.Business.Service.Boardgame;

[TestFixture]
public class BoardgameServiceTests
{
    private Mock<IBoardgameRepository> _mockBoardgameRepository;
    private Mock<IReviewsService> _mockReviewsService;
    private BoardGameService _service;
    
    [SetUp]
    public void Setup()
    {   
        _mockBoardgameRepository = new Mock<IBoardgameRepository>();
        _mockReviewsService = new Mock<IReviewsService>();

        _service = new BoardGameService(_mockBoardgameRepository.Object, _mockReviewsService.Object);
    }
    
    [Test]
    public void GetAllBoardgames_ValidRequest_ReturnsBoardgames()
    {
        // Arrange
        // Act
        var result = _service.GetAllBoardgames();

        // Assert
        Assert.AreEqual(2, result.Count);
    }
}