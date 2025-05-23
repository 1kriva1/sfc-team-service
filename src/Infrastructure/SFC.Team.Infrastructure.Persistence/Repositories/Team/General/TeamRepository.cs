using Microsoft.EntityFrameworkCore;

using SFC.Team.Application.Features.Common.Models;
using SFC.Team.Application.Features.Common.Models.Find.Paging;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Team.Infrastructure.Persistence.Contexts;
using SFC.Team.Infrastructure.Persistence.Extensions;
using SFC.Team.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Team.General;
public class TeamRepository(TeamDbContext context)
    : Repository<TeamEntity, TeamDbContext, long>(context), ITeamRepository
{
    public override Task<TeamEntity?> GetByIdAsync(long id)
    {
        return Context.Teams
                    .Include(p => p.GeneralProfile)
                    .Include(p => p.FinancialProfile)
                    .Include(p => p.Shirts)
                    .Include(p => p.Availability)
                    .Include(p => p.Tags)
                    .Include(p => p.Logo)
                    .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override Task<PagedList<TeamEntity>> FindAsync(FindParameters<TeamEntity> parameters)
    {
        return Context.Teams
                    .Include(p => p.GeneralProfile)
                    .Include(p => p.FinancialProfile)
                    .Include(p => p.Shirts)
                    .Include(p => p.Availability)
                    .Include(p => p.Tags)
                    .Include(p => p.Logo)
                    .AsQueryable()
                    .PaginateAsync(parameters);
    }

    public Task<bool> AnyAsync(long id)
    {
        return Context.Teams.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.Teams.AnyAsync(u => u.Id == id && u.UserId == userId);
    }

    public async Task<IEnumerable<TeamEntity>> GetByUserIdsAsync(IEnumerable<Guid> userIds)
    {
        return await Context.Teams.Include(p => p.GeneralProfile)
                            .Include(p => p.FinancialProfile)
                            .Include(p => p.Shirts)
                            .Include(p => p.Availability)
                            .Include(p => p.Tags)
                            .Include(p => p.Logo)
                            .Where(team => userIds.Contains(team.UserId))
                            .ToListAsync()
                            .ConfigureAwait(true);

    }

    public Task<TeamEntity?> GetByUserIdAsync(Guid userId)
    {
        return Context.Teams.Include(p => p.FinancialProfile)
                            .Include(p => p.Shirts)
                            .Include(p => p.Availability)
                            .Include(p => p.Tags)
                            .Include(p => p.Logo)
                            .FirstOrDefaultAsync(p => p.UserId == userId);
    }

    public async Task<TeamEntity[]> AddRangeIfNotExistsAsync(params TeamEntity[] entities)
    {
        await Context.Set<TeamEntity>().AddRangeIfNotExistsAsync<TeamEntity, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }
}