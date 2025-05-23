using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Metadata;
using SFC.Team.Infrastructure.Persistence.Configurations.Base;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Metadata;
public class MetadataDomainConfiguration : EnumEntityConfiguration<MetadataDomain, MetadataDomainEnum>
{
    public override void Configure(EntityTypeBuilder<MetadataDomain> builder)
    {
        builder.ToTable("Domains", DatabaseConstants.MetadataSchemaName);
        base.Configure(builder);
    }
}