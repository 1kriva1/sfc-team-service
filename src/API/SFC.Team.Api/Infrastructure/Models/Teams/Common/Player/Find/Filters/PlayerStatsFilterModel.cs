using SFC.Team.Api.Infrastructure.Models.Common;
using SFC.Team.Application.Common.Dto.Player.Filters;
using SFC.Team.Application.Common.Mappings.Interfaces;

namespace SFC.Team.Api.Infrastructure.Models.Teams.Common.Player.Find.Filters;

/// <summary>
/// Get players **stats filter** model.
/// </summary>
public class PlayerStatsFilterModel : IMapTo<PlayerStatsFilterDto>
{
    /// <summary>
    /// Filter by total rating.
    /// </summary>
    public RangeLimitModel<short?> Total { get; set; } = default!;

    /// <summary>
    /// Filter by physical stats rating.
    /// </summary>
    public PlayerStatsBySkillRangeLimitFilterModel Physical { get; set; } = default!;

    /// <summary>
    /// Filter by mental stats rating.
    /// </summary>
    public PlayerStatsBySkillRangeLimitFilterModel Mental { get; set; } = default!;

    /// <summary>
    /// Filter by skill stats rating.
    /// </summary>
    public PlayerStatsBySkillRangeLimitFilterModel Skill { get; set; } = default!;

    /// <summary>
    /// Filter by rating.
    /// </summary>
    public int? Raiting { get; set; }
}