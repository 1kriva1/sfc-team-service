using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Common.Extensions;
public static class TeamPlayerExtensions
{
    public static TeamPlayer SetStatus(this TeamPlayer value, TeamPlayerStatusEnum status)
    {
        value.StatusId = status;
        return value;
    }
}