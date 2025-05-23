﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Common;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Base;
public class BaseEntityConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity<TId>
    where TId : struct
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .HasColumnOrder(0)
               .IsRequired(true);
    }
}