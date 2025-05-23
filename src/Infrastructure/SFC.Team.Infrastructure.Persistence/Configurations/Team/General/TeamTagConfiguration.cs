using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Domain.Entities.Team.General;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Team.General;
public class TeamTagConfiguration : IEntityTypeConfiguration<TeamTag>
{
    public void Configure(EntityTypeBuilder<TeamTag> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.Value)
            .HasMaxLength(ValidationConstants.TagValueMaxLength)
            .IsRequired(true);

        builder.ToTable("Tags");
    }
}