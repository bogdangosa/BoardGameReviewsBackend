using System.ComponentModel;

namespace BoardGameReviewsBackend.API.Requests.Boardgames;

public class GetBoardgamesRequest
{
    [DefaultValue(1)]
    public int? page { get; set; }
    [DefaultValue(4)]
    public int? itemsPerPage { get; set; }
    [DefaultValue("none")]
    public string? sortOrder { get; set; }
    [DefaultValue("all")]
    public string? category { get; set; }
}