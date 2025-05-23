using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Domain.Common;
using SFC.Team.Infrastructure.Persistence.Contexts;
using SFC.Team.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Invite.Data.Cache;
public class InviteDataCacheRepository<TEntity, TEnum>(InviteDataRepository<TEntity, TEnum> repository, ICache cache)
    : DataCacheRepository<TEntity, InviteDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }