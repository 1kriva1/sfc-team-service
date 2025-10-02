using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Team.General;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Team.General;
public class TeamInventaryProfileConfiguration : IEntityTypeConfiguration<TeamInventaryProfile>
{
    public void Configure(EntityTypeBuilder<TeamInventaryProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.HasManiches)
            .HasDefaultValue(false);

        builder.ToTable("InventaryProfiles");
    }
}