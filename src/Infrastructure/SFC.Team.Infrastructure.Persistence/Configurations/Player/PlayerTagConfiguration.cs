using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Domain.Entities.Player;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Player;
public class PlayerTagConfiguration : IEntityTypeConfiguration<PlayerTag>
{
    public void Configure(EntityTypeBuilder<PlayerTag> builder)
    {
        builder.Property(e => e.Value)
            .HasMaxLength(ValidationConstants.TagValueMaxLength)
            .IsRequired(true);

        builder.ToTable("Tags", DatabaseConstants.PlayerSchemaName);
    }
}