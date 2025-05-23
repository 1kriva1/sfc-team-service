using SFC.Team.Api.Infrastructure.Models.Teams.Common.Player.Find.Filters;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Player.Queries.Find.Dto.Filters;

namespace SFC.Team.Api.Infrastructure.Models.Teams.Players.Find.Filters;

/// <summary>
/// Get team players filter model.
/// </summary>
public class GetTeamPlayersFilterModel : IMapTo<GetTeamPlayersFilterDto>
{
    /// <summary>
    /// Team player filter model.
    /// </summary>
    public GetTeamPlayersTeamPlayerFilterModel? TeamPlayer { get; set; }

    /// <summary>
    /// Player filter model.
    /// </summary>
    public PlayerFilterModel? Player { get; set; }
}