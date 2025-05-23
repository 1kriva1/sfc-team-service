﻿using Microsoft.EntityFrameworkCore;

using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Domain.Entities.Identity;
using SFC.Team.Infrastructure.Persistence.Configurations.Identity;
using SFC.Team.Infrastructure.Persistence.Constants;
using SFC.Team.Infrastructure.Persistence.Interceptors;

namespace SFC.Team.Infrastructure.Persistence.Contexts;
public class IdentityDbContext(
    DbContextOptions<IdentityDbContext> options,
    AuditableEntitySaveChangesInterceptor auditableInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<IdentityDbContext>(options, eventsInterceptor), IIdentityDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableInterceptor = auditableInterceptor;

    public IQueryable<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.IdentitySchemaName);

        ApplyIdentityConfigurations(modelBuilder, Database.IsSqlServer());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    public static void ApplyIdentityConfigurations(ModelBuilder modelBuilder, bool isSqlServer)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration(isSqlServer));
    }
}