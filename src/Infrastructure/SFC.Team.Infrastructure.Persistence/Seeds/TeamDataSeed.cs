using Microsoft.EntityFrameworkCore;

using SFC.Team.Application.Interfaces.Common;
using SFC.Team.Domain.Entities.Team.Data;
using SFC.Team.Infrastructure.Persistence.Extensions;

namespace SFC.Team.Infrastructure.Persistence.Seeds;
public static class TeamDataSeed
{
    public static void SeedTeamData(this ModelBuilder builder, IDateTimeService dateTimeService)
    {
        builder.SeedDataEnumValues<TeamPlayerStatus, TeamPlayerStatusEnum>(@enum =>
            new TeamPlayerStatus(@enum).SetCreatedDate(dateTimeService));
    }
}