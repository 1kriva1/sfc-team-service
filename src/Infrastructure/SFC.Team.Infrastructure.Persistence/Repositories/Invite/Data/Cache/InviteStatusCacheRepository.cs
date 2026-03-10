using Microsoft.Extensions.DependencyInjection;

using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Application.Interfaces.Persistence.Repository.Invite.Data;
using SFC.Team.Domain.Entities.Invite.Data;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Invite.Data.Cache;
public class InviteStatusCacheRepository(InviteStatusRepository repository, [FromKeyedServices(CacheInstance.Invite)] ICache cache)
    : InviteDataCacheRepository<InviteStatus, InviteStatusEnum>(repository, cache), IInviteStatusRepository
{ }