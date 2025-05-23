using SFC.Team.Application.Common.Enums;

namespace SFC.Team.Application.Features.Team.Player.Commands.Update;
public class UpdateTeamPlayerCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.UpdateTeamPlayer; }

    public required UpdateTeamPlayerDto TeamPlayer { get; set; }

    public UpdateTeamPlayerCommand SetPlayerId(long playerId)
    {
        TeamPlayer.PlayerId = playerId;
        return this;
    }

    public UpdateTeamPlayerCommand SetTeamId(long teamId)
    {
        TeamPlayer.TeamId = teamId;
        return this;
    }

    public UpdateTeamPlayerCommand SetStatus(TeamPlayerStatusEnum status)
    {
        TeamPlayer.Status = (int)status;
        return this;
    }
}