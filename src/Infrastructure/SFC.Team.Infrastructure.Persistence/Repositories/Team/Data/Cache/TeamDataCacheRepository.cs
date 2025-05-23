using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Domain.Common;
using SFC.Team.Infrastructure.Persistence.Contexts;
using SFC.Team.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Team.Data.Cache;
public class TeamDataCacheRepository<T, TEnum>(TeamDataRepository<T, TEnum> repository, ICache cache)
    : DataCacheRepository<T, TeamDbContext, TEnum>(repository, cache)
     where T : EnumDataEntity<TEnum>
     where TEnum : struct
{
}