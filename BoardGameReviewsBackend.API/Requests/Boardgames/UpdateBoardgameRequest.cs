using FluentValidation;

namespace BoardGameReviewsBackend.API.Requests.Boardgames;

public class UpdateBoardgameRequest
{
    public int BoardgameId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int? nrOfPlayers { get; set; }
    public int? playTime { get; set; }
    public int? weight { get; set; }
    public int? rating { get; set; }
}

public class UpdateBoardgameRequestValidator : AbstractValidator<AddBoardgameRequest>
{
    public UpdateBoardgameRequestValidator()
    {
        RuleFor(request => request.Title).NotEmpty().Must(title=> title.Length is > 0 and <= 50);
        RuleFor(request => request.Description).NotEmpty().Must(title=> title.Length is > 0 and <= 200);
        RuleFor(request => request.Category).NotEmpty().Must(category => category.Length is > 0 and <= 50);
    }
}