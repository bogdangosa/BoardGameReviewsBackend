using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameReviewsBackend.Data.Configurations;

public class MonitoredUserConfiguration: IEntityTypeConfiguration<Models.MonitoredUser>
{
    public void Configure(EntityTypeBuilder<Models.MonitoredUser> builder)
    {
        builder.HasKey(monitoredUser =>  monitoredUser.monitoredId);
    }
}
