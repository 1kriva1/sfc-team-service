using SFC.Team.Application.Common.Enums;
using SFC.Team.Application.Features.Common.Base;

namespace SFC.Team.Application.Features.Team.General.Commands.Create;
public class CreateTeamCommand : Request<CreateTeamViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateTeam; }

    public CreateTeamDto Team { get; set; } = null!;
}