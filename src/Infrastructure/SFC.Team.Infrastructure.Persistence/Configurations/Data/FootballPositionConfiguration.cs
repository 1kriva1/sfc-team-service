using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Data;
using SFC.Team.Infrastructure.Persistence.Configurations.Base;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Data;
public class FootballPositionConfiguration : EnumDataEntityConfiguration<FootballPosition, FootballPositionEnum>
{
    public override void Configure(EntityTypeBuilder<FootballPosition> builder)
    {
        builder.ToTable("FootballPositions", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}