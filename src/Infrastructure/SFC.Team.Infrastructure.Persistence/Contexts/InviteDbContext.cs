using Microsoft.EntityFrameworkCore;

using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Domain.Entities.Invite.Data;
using SFC.Team.Infrastructure.Persistence.Configurations.Invite.Data;
using SFC.Team.Infrastructure.Persistence.Constants;
using SFC.Team.Infrastructure.Persistence.Interceptors;

namespace SFC.Team.Infrastructure.Persistence.Contexts;
public class InviteDbContext(
    DbContextOptions<InviteDbContext> options,
    DataEntitySaveChangesInterceptor dataEntityInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<InviteDbContext>(options, eventsInterceptor), IInviteDbContext
{
    private readonly DataEntitySaveChangesInterceptor _dataEntityInterceptor = dataEntityInterceptor;

    #region Data

    public IQueryable<InviteStatus> InviteStatuses => Set<InviteStatus>();

    #endregion Data

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.DataSchemaName);

        // data
        ApplyInviteConfigurations(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    public static void ApplyInviteConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InviteStatusConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_dataEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}