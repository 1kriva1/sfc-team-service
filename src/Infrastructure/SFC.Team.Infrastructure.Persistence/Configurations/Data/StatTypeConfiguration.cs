using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Data;
using SFC.Team.Infrastructure.Persistence.Configurations.Base;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Data;
public class StatTypeConfiguration : EnumDataEntityConfiguration<StatType, StatTypeEnum>
{
    public override void Configure(EntityTypeBuilder<StatType> builder)
    {
        builder.ToTable("StatTypes", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}