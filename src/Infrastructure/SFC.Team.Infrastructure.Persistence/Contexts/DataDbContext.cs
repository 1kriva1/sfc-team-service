﻿using Microsoft.EntityFrameworkCore;

using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Domain.Entities.Data;
using SFC.Team.Infrastructure.Persistence.Configurations.Data;
using SFC.Team.Infrastructure.Persistence.Constants;
using SFC.Team.Infrastructure.Persistence.Interceptors;

namespace SFC.Team.Infrastructure.Persistence.Contexts;
public class DataDbContext(
    DbContextOptions<DataDbContext> options,
    DataEntitySaveChangesInterceptor dataEntityInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<DataDbContext>(options, eventsInterceptor), IDataDbContext
{
    private readonly DataEntitySaveChangesInterceptor _dataEntityInterceptor = dataEntityInterceptor;

    public IQueryable<GameStyle> GameStyles => Set<GameStyle>();

    public IQueryable<FootballPosition> FootballPositions => Set<FootballPosition>();

    public IQueryable<StatCategory> StatCategories => Set<StatCategory>();

    public IQueryable<StatSkill> StatSkills => Set<StatSkill>();

    public IQueryable<StatType> StatTypes => Set<StatType>();

    public IQueryable<WorkingFoot> WorkingFoots => Set<WorkingFoot>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.DataSchemaName);

        // data
        ApplyDataConfigurations(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    public static void ApplyDataConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ShirtConfiguration());

        modelBuilder.ApplyConfiguration(new GameStyleConfiguration());

        modelBuilder.ApplyConfiguration(new FootballPositionConfiguration());

        modelBuilder.ApplyConfiguration(new StatCategoryConfiguration());

        modelBuilder.ApplyConfiguration(new StatSkillConfiguration());

        modelBuilder.ApplyConfiguration(new StatTypeConfiguration());

        modelBuilder.ApplyConfiguration(new WorkingFootConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_dataEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}