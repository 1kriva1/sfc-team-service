using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Team.Data;
using SFC.Team.Infrastructure.Persistence.Configurations.Base;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Team.Data;
public class TeamPlayerStatusConfiguration : EnumDataEntityConfiguration<TeamPlayerStatus, TeamPlayerStatusEnum>
{
    public override void Configure(EntityTypeBuilder<TeamPlayerStatus> builder)
    {
        builder.ToTable("PlayerStatuses", DatabaseConstants.DefaultSchemaName);
        base.Configure(builder);
    }
}