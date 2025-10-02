using Microsoft.EntityFrameworkCore;

using SFC.Team.Application.Interfaces.Persistence.Repository.Player.General;
using SFC.Team.Infrastructure.Persistence.Contexts;
using SFC.Team.Infrastructure.Persistence.Extensions;
using SFC.Team.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Player;
public class PlayerRepository(PlayerDbContext context)
    : Repository<PlayerEntity, PlayerDbContext, long>(context), IPlayerRepository
{
    public override Task<PlayerEntity?> GetByIdAsync(long id)
    {
        return Context.Players
                      .IncludePlayer()
                      .FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task<PlayerEntity?> GetByUserIdAsync(Guid userId)
    {
        return Context.Players.FirstOrDefaultAsync(p => p.UserId == userId);
    }

    public async Task<PlayerEntity[]> AddRangeIfNotExistsAsync(params PlayerEntity[] entities)
    {
        await Context.Set<PlayerEntity>().AddRangeIfNotExistsAsync<PlayerEntity, long>(entities).ConfigureAwait(false);

        await Context.SaveChangesAsync().ConfigureAwait(false);

        return entities;
    }

    public Task<bool> AnyAsync(long id)
    {
        return Context.Players.AnyAsync(p => p.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.Players.AnyAsync(p => p.Id == id && p.UserId == userId);
    }
}