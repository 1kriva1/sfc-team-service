using Microsoft.Extensions.DependencyInjection;

using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Application.Interfaces.Persistence.Repository.Request.Data;
using SFC.Team.Domain.Entities.Request.Data;
using SFC.Team.Infrastructure.Persistence.Constants;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Request.Data.Cache;
public class RequestStatusCacheRepository(RequestStatusRepository repository, [FromKeyedServices(CacheInstance.Request)] ICache cache)
    : RequestDataCacheRepository<RequestStatus, RequestStatusEnum>(repository, cache), IRequestStatusRepository
{ }