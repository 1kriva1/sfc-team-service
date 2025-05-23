using SFC.Team.Application.Common.Enums;
using SFC.Team.Application.Features.Common.Base;

namespace SFC.Team.Application.Features.Team.General.Queries.Get;

public class GetTeamQuery : Request<GetTeamViewModel>
{
    public override RequestId RequestId { get => RequestId.GetTeam; }

    public long TeamId { get; set; }
}