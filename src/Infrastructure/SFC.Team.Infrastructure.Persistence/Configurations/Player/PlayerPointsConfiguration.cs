using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Player;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Player;
public class PlayerPointsConfiguration : IEntityTypeConfiguration<PlayerStatPoints>
{
    public void Configure(EntityTypeBuilder<PlayerStatPoints> builder)
    {
        builder.Property(e => e.Available)
            .HasDefaultValue(0);

        builder.Property(e => e.Used)
            .HasDefaultValue(0);

        builder.ToTable("Points", DatabaseConstants.PlayerSchemaName);
    }
}