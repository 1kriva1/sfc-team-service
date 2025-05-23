using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Metadata;
using SFC.Team.Infrastructure.Persistence.Configurations.Base;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Metadata;
public class MetadataTypeConfiguration : EnumEntityConfiguration<MetadataType, MetadataTypeEnum>
{
    public override void Configure(EntityTypeBuilder<MetadataType> builder)
    {
        builder.ToTable("Types", DatabaseConstants.MetadataSchemaName);
        base.Configure(builder);
    }
}