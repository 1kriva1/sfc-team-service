using SFC.Team.Application.Common.Enums;

namespace SFC.Team.Application.Features.Team.General.Commands.Update;
public class UpdateTeamCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.UpdateTeam; }

    public long TeamId { get; set; }

    public required UpdateTeamDto Team { get; set; }

    public UpdateTeamCommand SetTeamId(long id)
    {
        TeamId = id;
        return this;
    }
}