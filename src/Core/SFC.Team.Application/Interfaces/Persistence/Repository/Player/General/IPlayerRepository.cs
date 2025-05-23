using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.Team.Application.Interfaces.Persistence.Repository.Player.General;
public interface IPlayerRepository : IRepository<PlayerEntity, IPlayerDbContext, long>
{
    Task<PlayerEntity[]> AddRangeIfNotExistsAsync(params PlayerEntity[] entities);

    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);
}