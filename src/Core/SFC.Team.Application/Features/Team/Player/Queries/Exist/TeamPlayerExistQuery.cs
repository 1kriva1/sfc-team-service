using SFC.Team.Application.Common.Enums;
using SFC.Team.Application.Features.Common.Base;

namespace SFC.Team.Application.Features.Team.Player.Queries.Exist;

public class TeamPlayerExistQuery : Request<TeamPlayerExistViewModel>
{
    public override RequestId RequestId { get => RequestId.TeamPlayerExist; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public TeamPlayerStatusEnum? Status { get; set; }
}