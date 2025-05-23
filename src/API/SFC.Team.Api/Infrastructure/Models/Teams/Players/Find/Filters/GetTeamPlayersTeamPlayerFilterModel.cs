using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Player.Queries.Find.Dto.Filters;

namespace SFC.Team.Api.Infrastructure.Models.Teams.Players.Find.Filters;

/// <summary>
/// Get team players for team player filter model.
/// </summary>
public class GetTeamPlayersTeamPlayerFilterModel : IMapTo<GetTeamPlayersTeamPlayerFilterDto>
{
    /// <summary>
    /// Statuses of team player.
    /// </summary>
    public IEnumerable<int> Statuses { get; set; } = default!;
}