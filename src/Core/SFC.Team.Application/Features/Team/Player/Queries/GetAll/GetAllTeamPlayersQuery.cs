using SFC.Team.Application.Common.Enums;
using SFC.Team.Application.Features.Common.Base;

namespace SFC.Team.Application.Features.Team.Player.Queries.GetAll;

public class GetAllTeamPlayersQuery : Request<GetAllTeamPlayersViewModel>
{
    public override RequestId RequestId { get => RequestId.GetAllTeamPlayers; }

    public long TeamId { get; set; }
}