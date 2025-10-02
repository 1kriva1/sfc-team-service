using Microsoft.EntityFrameworkCore;

using SFC.Team.Application.Features.Common.Models.Find;
using SFC.Team.Application.Features.Common.Models.Find.Paging;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Team.Domain.Entities.Team.Player;
using SFC.Team.Infrastructure.Persistence.Contexts;
using SFC.Team.Infrastructure.Persistence.Extensions;
using SFC.Team.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Team.Player;
public class TeamPlayerRepository(TeamDbContext context)
    : Repository<TeamPlayer, TeamDbContext, long>(context), ITeamPlayerRepository
{
    public override Task<PagedList<TeamPlayer>> FindAsync(FindParameters<TeamPlayer> parameters)
    {
        return Context.TeamPlayers
                      .ThanIncludePlayer()
                      .AsQueryable()
                      .PaginateAsync(parameters);
    }

    public Task<TeamPlayer?> GetByIdAsync(long teamId, long playerId)
    {
        return Context.TeamPlayers.FirstOrDefaultAsync(item => item.TeamId == teamId && item.Player.Id == playerId);
    }

    public Task<TeamPlayer?> GetByIdAsync(long id, long teamId, long playerId)
    {
        return Context.TeamPlayers
                      .Include(x => x.Player)
                      .FirstOrDefaultAsync(item => item.Id == id && item.TeamId == teamId && item.Player.Id == playerId);
    }

    public async Task<IReadOnlyList<TeamPlayer>> GetByIdsAsync(IEnumerable<long> teamIds, IEnumerable<long> playerIds)
    {
        return await Context.TeamPlayers
                            .Where(teamPlayer => teamIds.Contains(teamPlayer.TeamId) && playerIds.Contains(teamPlayer.PlayerId))
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public async Task<IReadOnlyList<TeamPlayer>> ListAllAsync(long teamId)
    {
        return await Context.TeamPlayers
                            .ThanIncludePlayer()
                            .Where(teamPlayer => teamPlayer.TeamId == teamId)
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public async Task<IReadOnlyList<TeamPlayer>> ListAllAsync(long teamId, TeamPlayerStatusEnum status)
    {
        return await Context.TeamPlayers
                            .ThanIncludePlayer()
                            .Where(teamPlayer => teamPlayer.TeamId == teamId && teamPlayer.StatusId == status)
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public Task<bool> AnyAsync(long teamId, long playerId)
    {
        return Context.TeamPlayers.AnyAsync(item => item.TeamId == teamId && item.Player.Id == playerId);
    }

    public Task<bool> AnyAsync(long teamId, long playerId, TeamPlayerStatusEnum? status)
    {
        return status.HasValue
            ? Context.TeamPlayers.AnyAsync(item => item.TeamId == teamId && item.Player.Id == playerId && item.StatusId == status)
            : Context.TeamPlayers.AnyAsync(item => item.TeamId == teamId && item.Player.Id == playerId);
    }

    public async Task<TeamPlayer[]> AddRangeIfNotExistsAsync(params TeamPlayer[] entities)
    {
        await Context.Set<TeamPlayer>().AddRangeIfNotExistsAsync<TeamPlayer, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }
}