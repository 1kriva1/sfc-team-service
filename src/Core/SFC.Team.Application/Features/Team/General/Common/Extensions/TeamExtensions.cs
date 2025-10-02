using SFC.Team.Domain.Entities.Team.Player;
using SFC.Team.Domain.Events.Team.Player;

namespace SFC.Team.Application.Features.Team.General.Common.Extensions;
public static class TeamExtensions
{
    public static TeamEntity SetStatus(this TeamEntity value, TeamStatusEnum status)
    {
        value.StatusId = status;
        return value;
    }

    public static TeamEntity AddUserPlayer(this TeamEntity value, PlayerEntity player)
    {
        TeamPlayer userTeamPlayer = new() { PlayerId = player.Id, StatusId = TeamPlayerStatusEnum.Active };

        //TODO error when create team in one time with create team player
        //userTeamPlayer.AddDomainEvent(new TeamPlayerCreatedEvent(userTeamPlayer));

        value.Players.Add(userTeamPlayer);

        return value;
    }
}