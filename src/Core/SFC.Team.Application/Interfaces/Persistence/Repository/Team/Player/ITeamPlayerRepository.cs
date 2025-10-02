using System.Collections.Generic;

using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Application.Interfaces.Persistence.Repository.Common;
using SFC.Team.Domain.Common.Interfaces;
using SFC.Team.Domain.Entities.Team;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Interfaces.Persistence.Repository.Team.Player;
public interface ITeamPlayerRepository : IRepository<TeamPlayer, ITeamDbContext, long>
{
    Task<TeamPlayer?> GetByIdAsync(long teamId, long playerId);

    Task<TeamPlayer?> GetByIdAsync(long id, long teamId, long playerId);

    Task<IReadOnlyList<TeamPlayer>> GetByIdsAsync(IEnumerable<long> teamIds, IEnumerable<long> playerIds);

    Task<IReadOnlyList<TeamPlayer>> ListAllAsync(long teamId);

    Task<IReadOnlyList<TeamPlayer>> ListAllAsync(long teamId, TeamPlayerStatusEnum status);

    Task<bool> AnyAsync(long teamId, long playerId);

    Task<bool> AnyAsync(long teamId, long playerId, TeamPlayerStatusEnum? status);

    Task<TeamPlayer[]> AddRangeIfNotExistsAsync(params TeamPlayer[] entities);
}