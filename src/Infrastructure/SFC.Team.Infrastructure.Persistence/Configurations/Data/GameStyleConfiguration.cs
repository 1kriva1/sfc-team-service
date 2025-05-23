using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Data;
using SFC.Team.Infrastructure.Persistence.Configurations.Base;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Data;
public class GameStyleConfiguration : EnumDataEntityConfiguration<GameStyle, GameStyleEnum>
{
    public override void Configure(EntityTypeBuilder<GameStyle> builder)
    {
        builder.ToTable("GameStyles", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}