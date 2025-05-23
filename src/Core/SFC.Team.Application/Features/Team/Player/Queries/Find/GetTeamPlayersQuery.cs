using SFC.Team.Application.Common.Enums;
using SFC.Team.Application.Features.Common.Base;
using SFC.Team.Application.Features.Team.Player.Queries.Find.Dto.Filters;

namespace SFC.Team.Application.Features.Team.Player.Queries.Find;
public class GetTeamPlayersQuery : BasePaginationRequest<GetTeamPlayersViewModel, GetTeamPlayersFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetTeamPlayers; }
}