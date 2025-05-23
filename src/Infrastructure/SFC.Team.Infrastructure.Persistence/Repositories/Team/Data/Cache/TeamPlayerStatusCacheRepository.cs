using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Team.Domain.Entities.Team.Data;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Team.Data.Cache;
public class TeamPlayerStatusCacheRepository(TeamPlayerStatusRepository repository, ICache cache)
    : TeamDataCacheRepository<TeamPlayerStatus, TeamPlayerStatusEnum>(repository, cache), ITeamPlayerStatusRepository
{ }