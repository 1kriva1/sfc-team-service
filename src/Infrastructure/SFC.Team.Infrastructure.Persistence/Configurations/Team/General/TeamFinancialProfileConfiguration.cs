using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Team.General;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Team.General;
public class TeamFinancialProfileConfiguration : IEntityTypeConfiguration<TeamFinancialProfile>
{
    public void Configure(EntityTypeBuilder<TeamFinancialProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.FreePlay)
            .HasDefaultValue(false);

        builder.ToTable("FinancialProfiles");
    }
}