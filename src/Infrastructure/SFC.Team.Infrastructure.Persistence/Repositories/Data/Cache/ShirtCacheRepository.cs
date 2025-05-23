using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Application.Interfaces.Persistence.Repository.Data;
using SFC.Team.Domain.Entities.Data;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Data.Cache;
public class ShirtCacheRepository(ShirtRepository repository, ICache cache)
    : DataCacheRepository<Shirt, ShirtEnum>(repository, cache), IShirtRepository
{ }