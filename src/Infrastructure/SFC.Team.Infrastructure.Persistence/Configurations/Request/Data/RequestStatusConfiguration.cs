using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Request.Data;
using SFC.Team.Infrastructure.Persistence.Configurations.Base;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Request.Data;
public class RequestStatusConfiguration : EnumDataEntityConfiguration<RequestStatus, RequestStatusEnum>
{
    public override void Configure(EntityTypeBuilder<RequestStatus> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("RequestStatuses", DatabaseConstants.RequestSchemaName);
        base.Configure(builder);
    }
}