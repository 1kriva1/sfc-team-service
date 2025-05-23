using SFC.Team.Application.Common.Enums;
using SFC.Team.Application.Features.Common.Base;

namespace SFC.Team.Application.Features.Team.Player.Queries.Get;

public class GetTeamPlayerQuery : Request<GetTeamPlayerViewModel>
{
    public override RequestId RequestId { get => RequestId.GetTeamPlayer; }

    public long Id { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }
}