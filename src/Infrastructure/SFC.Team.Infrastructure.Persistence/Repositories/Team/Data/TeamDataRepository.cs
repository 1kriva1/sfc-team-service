using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Team.Domain.Common;
using SFC.Team.Infrastructure.Persistence.Contexts;
using SFC.Team.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Team.Data;
public class TeamDataRepository<T, TEnum>(TeamDbContext context)
     : DataRepository<T, TeamDbContext, TEnum>(context), ITeamDataRepository<T, TEnum>
     where T : EnumDataEntity<TEnum>
     where TEnum : struct
{
}