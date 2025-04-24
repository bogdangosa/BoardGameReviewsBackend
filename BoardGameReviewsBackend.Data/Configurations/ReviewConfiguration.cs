using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameReviewsBackend.Data.Configurations;

public class ReviewConfiguration: IEntityTypeConfiguration<Models.Review>
{
    public void Configure(EntityTypeBuilder<Models.Review> builder)
    {
        builder.HasKey(review =>  review.reviewId);
    }
}