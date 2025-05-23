using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Metadata;
using SFC.Team.Infrastructure.Persistence.Configurations.Base;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Metadata;
public class MetadataStateConfiguration : EnumEntityConfiguration<MetadataState, MetadataStateEnum>
{
    public override void Configure(EntityTypeBuilder<MetadataState> builder)
    {
        builder.ToTable("States", DatabaseConstants.MetadataSchemaName);
        base.Configure(builder);
    }
}