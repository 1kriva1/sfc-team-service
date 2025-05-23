using SFC.Team.Domain.Entities.Data;

namespace SFC.Team.Application.Interfaces.Persistence.Context;
public interface IDataDbContext : IDbContext
{
    IQueryable<GameStyle> GameStyles { get; }

    IQueryable<FootballPosition> FootballPositions { get; }

    IQueryable<StatCategory> StatCategories { get; }

    IQueryable<StatSkill> StatSkills { get; }

    IQueryable<StatType> StatTypes { get; }

    IQueryable<WorkingFoot> WorkingFoots { get; }
}