using SFC.Team.Api.Infrastructure.Models.Common;
using SFC.Team.Application.Common.Dto.Player.Filters;
using SFC.Team.Application.Common.Mappings.Interfaces;

namespace SFC.Team.Api.Infrastructure.Models.Teams.Common.Player.Find.Filters;

/// <summary>
/// Range limit by **stat skill**.
/// </summary>
public class PlayerStatsBySkillRangeLimitFilterModel :
    RangeLimitModel<short?>,
    IMapTo<PlayerStatsBySkillRangeLimitFilterDto>
{
    /// <summary>
    /// Stat skill unique identifier.
    /// </summary>
    public int Skill { get; set; }
}