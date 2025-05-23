using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.Team.Application.Interfaces.Persistence.Repository.Team.General;
public interface ITeamRepository : IRepository<TeamEntity, ITeamDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<IEnumerable<TeamEntity>> GetByUserIdsAsync(IEnumerable<Guid> userIds);

    Task<TeamEntity?> GetByUserIdAsync(Guid userId);

    Task<TeamEntity[]> AddRangeIfNotExistsAsync(params TeamEntity[] entities);
}