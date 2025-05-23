using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using SFC.Team.Application.Interfaces.Common;
using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Domain.Entities.Team.Data;
using SFC.Team.Domain.Entities.Team.General;
using SFC.Team.Domain.Entities.Team.Player;
using SFC.Team.Infrastructure.Persistence.Constants;
using SFC.Team.Infrastructure.Persistence.Interceptors;
using SFC.Team.Infrastructure.Persistence.Seeds;

namespace SFC.Team.Infrastructure.Persistence.Contexts;
public class TeamDbContext(
    IDateTimeService dateTimeService,
    IHostEnvironment hostEnvironment,
    DbContextOptions<TeamDbContext> options,
    AuditableEntitySaveChangesInterceptor auditableInterceptor,
    UserEntitySaveChangesInterceptor userEntityInterceptor,
    PlayerEntitySaveChangesInterceptor playerEntityInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<TeamDbContext>(options, eventsInterceptor), ITeamDbContext
{
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly AuditableEntitySaveChangesInterceptor _auditableInterceptor = auditableInterceptor;
    private readonly UserEntitySaveChangesInterceptor _userEntityInterceptor = userEntityInterceptor;
    private readonly PlayerEntitySaveChangesInterceptor _playerEntityInterceptor = playerEntityInterceptor;

    public IQueryable<TeamEntity> Teams => Set<TeamEntity>();

    public IQueryable<TeamGeneralProfile> GeneralProfiles => Set<TeamGeneralProfile>();

    public IQueryable<TeamFinancialProfile> FinancialProfiles => Set<TeamFinancialProfile>();

    public IQueryable<TeamAvailability> Availability => Set<TeamAvailability>();

    public IQueryable<TeamTag> Tags => Set<TeamTag>();

    public IQueryable<TeamShirt> Shirts => Set<TeamShirt>();

    public IQueryable<TeamLogo> Logos => Set<TeamLogo>();

    public IQueryable<TeamPlayer> TeamPlayers => Set<TeamPlayer>();

    #region Data

    public IQueryable<TeamPlayerStatus> TeamPlayerStatuses => Set<TeamPlayerStatus>();

    #endregion Data

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.DefaultSchemaName);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // seed team data
        modelBuilder.SeedTeamData(_dateTimeService);

        // invite
        InviteDbContext.ApplyInviteConfigurations(modelBuilder);

        // request
        RequestDbContext.ApplyRequestConfigurations(modelBuilder);

        // metadata
        MetadataDbContext.ApplyMetadataConfigurations(modelBuilder, _hostEnvironment.IsDevelopment());

        // identity
        IdentityDbContext.ApplyIdentityConfigurations(modelBuilder, Database.IsSqlServer());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableInterceptor);
        optionsBuilder.AddInterceptors(_userEntityInterceptor);
        optionsBuilder.AddInterceptors(_playerEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}