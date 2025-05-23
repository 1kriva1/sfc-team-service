using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Data;
using SFC.Team.Infrastructure.Persistence.Configurations.Base;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Data;
public class ShirtConfiguration : EnumDataEntityConfiguration<Shirt, ShirtEnum>
{
    public override void Configure(EntityTypeBuilder<Shirt> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("Shirts", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}