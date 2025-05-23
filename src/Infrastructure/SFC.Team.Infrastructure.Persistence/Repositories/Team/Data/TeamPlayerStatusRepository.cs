using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Team.Domain.Entities.Team.Data;
using SFC.Team.Infrastructure.Persistence.Contexts;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Team.Data;
public class TeamPlayerStatusRepository(TeamDbContext context)
    : TeamDataRepository<TeamPlayerStatus, TeamPlayerStatusEnum>(context), ITeamPlayerStatusRepository
{ }