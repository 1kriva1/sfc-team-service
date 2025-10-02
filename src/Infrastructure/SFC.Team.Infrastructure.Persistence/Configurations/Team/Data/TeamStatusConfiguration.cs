using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Team.Data;
using SFC.Team.Infrastructure.Persistence.Configurations.Base;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Team.Data;
public class TeamStatusConfiguration : EnumDataEntityConfiguration<TeamStatus, TeamStatusEnum>
{
    public override void Configure(EntityTypeBuilder<TeamStatus> builder)
    {
        builder.ToTable("Statuses", DatabaseConstants.DefaultSchemaName);
        base.Configure(builder);
    }
}