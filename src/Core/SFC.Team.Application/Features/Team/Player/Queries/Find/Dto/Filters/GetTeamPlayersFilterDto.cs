using SFC.Team.Application.Common.Dto.Player.Filters;

namespace SFC.Team.Application.Features.Team.Player.Queries.Find.Dto.Filters;
public class GetTeamPlayersFilterDto
{
    public GetTeamPlayersTeamPlayerFilterDto? TeamPlayer { get; set; }

    public PlayerFilterDto? Player { get; set; }
}