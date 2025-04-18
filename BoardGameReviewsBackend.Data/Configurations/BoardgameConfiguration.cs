using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameReviewsBackend.Data.Configurations;

public class BoardgameConfiguration : IEntityTypeConfiguration<Models.Boardgame>
{
    public void Configure(EntityTypeBuilder<Models.Boardgame> builder)
    {
        builder.HasKey(boardgame =>  boardgame.boardgameid);
    }
}