using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Domain.Common;
using SFC.Team.Infrastructure.Persistence.Contexts;
using SFC.Team.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Data.Cache;
public class DataCacheRepository<T, TEnum>(DataRepository<T, TEnum> repository, ICache cache)
    : DataCacheRepository<T, DataDbContext, TEnum>(repository, cache)
     where T : EnumDataEntity<TEnum>
     where TEnum : struct
{
}