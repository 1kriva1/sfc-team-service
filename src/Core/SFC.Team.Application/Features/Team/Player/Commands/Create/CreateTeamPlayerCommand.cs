using SFC.Team.Application.Common.Enums;
using SFC.Team.Application.Features.Common.Base;

namespace SFC.Team.Application.Features.Team.Player.Commands.Create;
public class CreateTeamPlayerCommand : Request<CreateTeamPlayerViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateTeamPlayer; }

    public required CreateTeamPlayerDto TeamPlayer { get; set; }

    public CreateTeamPlayerCommand SetPlayerId(long playerId)
    {
        TeamPlayer.PlayerId = playerId;
        return this;
    }

    public CreateTeamPlayerCommand SetTeamId(long teamId)
    {
        TeamPlayer.TeamId = teamId;
        return this;
    }
}