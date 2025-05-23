﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Metadata;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Metadata;
public class MetadataConfiguration : IEntityTypeConfiguration<MetadataEntity>
{
    public void Configure(EntityTypeBuilder<MetadataEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasKey(e => new { e.Service, e.Type, e.Domain });

        builder.HasOne<MetadataService>()
               .WithMany()
               .HasForeignKey(t => t.Service)
               .IsRequired(true);

        builder.HasOne<MetadataType>()
              .WithMany()
              .HasForeignKey(t => t.Type)
              .IsRequired(true);

        builder.HasOne<MetadataState>()
               .WithMany()
               .HasForeignKey(t => t.State)
               .IsRequired(true);

        builder.HasOne<MetadataDomain>()
               .WithMany()
               .HasForeignKey(t => t.Domain)
               .IsRequired(true);

        builder.ToTable("Metadata", DatabaseConstants.MetadataSchemaName);
    }
}