using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Application.Interfaces.Persistence.Repository.Data;
using SFC.Team.Domain.Entities.Data;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Data.Cache;
public class GameStyleCacheRepository(GameStyleRepository repository, ICache cache)
    : DataCacheRepository<GameStyle, GameStyleEnum>(repository, cache), IGameStyleRepository
{ }