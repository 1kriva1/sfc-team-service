using Microsoft.Extensions.DependencyInjection;

using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Domain.Common;
using SFC.Team.Infrastructure.Persistence.Constants;
using SFC.Team.Infrastructure.Persistence.Contexts;
using SFC.Team.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Request.Data.Cache;
public class RequestDataCacheRepository<TEntity, TEnum>(RequestDataRepository<TEntity, TEnum> repository, [FromKeyedServices(CacheInstance.Request)] ICache cache)
    : DataRelatedCacheRepository<TEntity, RequestDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }