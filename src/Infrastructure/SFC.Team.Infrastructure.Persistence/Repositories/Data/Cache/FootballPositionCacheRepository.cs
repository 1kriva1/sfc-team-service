using Microsoft.Extensions.DependencyInjection;

using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Application.Interfaces.Persistence.Repository.Data;
using SFC.Team.Domain.Entities.Data;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Data.Cache;
public class FootballPositionCacheRepository(FootballPositionRepository repository, [FromKeyedServices(CacheInstance.Data)] ICache cache)
    : DataCacheRepository<FootballPosition, FootballPositionEnum>(repository, cache), IFootballPositionRepository
{ }