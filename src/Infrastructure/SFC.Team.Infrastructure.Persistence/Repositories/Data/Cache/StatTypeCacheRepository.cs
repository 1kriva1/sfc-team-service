using Microsoft.Extensions.DependencyInjection;

using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Application.Interfaces.Persistence.Repository.Data;
using SFC.Team.Domain.Entities.Data;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Data.Cache;
public class StatTypeCacheRepository(StatTypeRepository repository, [FromKeyedServices(CacheInstance.Data)] ICache cache)
    : DataCacheRepository<StatType, StatTypeEnum>(repository, cache), IStatTypeRepository
{
#pragma warning disable CA1859 // Use concrete types when possible for improved performance
    private readonly IStatTypeRepository _repository = repository;
#pragma warning restore CA1859 // Use concrete types when possible for improved performance

    public Task<int> CountAsync()
    {
        return !Cache.TryGet(CacheKey, out IReadOnlyList<StatType> entities)
            ? _repository.CountAsync()
            : Task.FromResult(entities.Count);
    }
}