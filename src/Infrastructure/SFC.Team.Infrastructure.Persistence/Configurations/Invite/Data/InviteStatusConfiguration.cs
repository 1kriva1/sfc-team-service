﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Invite.Data;
using SFC.Team.Infrastructure.Persistence.Configurations.Base;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Invite.Data;
public class InviteStatusConfiguration : EnumDataEntityConfiguration<InviteStatus, InviteStatusEnum>
{
    public override void Configure(EntityTypeBuilder<InviteStatus> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("InviteStatuses", DatabaseConstants.InviteSchemaName);
        base.Configure(builder);
    }
}