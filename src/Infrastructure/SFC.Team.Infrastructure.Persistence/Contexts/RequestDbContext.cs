using Microsoft.EntityFrameworkCore;

using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Domain.Entities.Request.Data;
using SFC.Team.Infrastructure.Persistence.Configurations.Request.Data;
using SFC.Team.Infrastructure.Persistence.Constants;
using SFC.Team.Infrastructure.Persistence.Interceptors;

namespace SFC.Team.Infrastructure.Persistence.Contexts;
public class RequestDbContext(
    DbContextOptions<RequestDbContext> options,
    DataEntitySaveChangesInterceptor dataEntityInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<RequestDbContext>(options, eventsInterceptor), IRequestDbContext
{
    private readonly DataEntitySaveChangesInterceptor _dataEntityInterceptor = dataEntityInterceptor;

    #region Data

    public IQueryable<RequestStatus> RequestStatuses => Set<RequestStatus>();

    #endregion Data

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.DataSchemaName);

        // data
        ApplyRequestConfigurations(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    public static void ApplyRequestConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RequestStatusConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_dataEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}