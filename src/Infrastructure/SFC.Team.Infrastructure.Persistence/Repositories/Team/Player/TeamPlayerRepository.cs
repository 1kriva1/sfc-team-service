using Microsoft.EntityFrameworkCore;

using SFC.Team.Application.Features.Common.Models;
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
                      .Include(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Player).ThenInclude(p => p.Photo)
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

    public async Task<IEnumerable<TeamPlayer>> GetByIdsAsync(IEnumerable<long> teamIds, IEnumerable<long> playerIds)
    {
        return await Context.TeamPlayers
                            .Where(teamPlayer => teamIds.Contains(teamPlayer.TeamId) && playerIds.Contains(teamPlayer.PlayerId))
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public Task<bool> AnyAsync(long teamId, long playerId)
    {
        return Context.TeamPlayers.AnyAsync(item => item.TeamId == teamId && item.Player.Id == playerId);
    }

    public async Task<TeamPlayer[]> AddRangeIfNotExistsAsync(params TeamPlayer[] entities)
    {
        await Context.Set<TeamPlayer>().AddRangeIfNotExistsAsync<TeamPlayer, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }
}