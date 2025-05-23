using SFC.Team.Api.Infrastructure.Models.Common;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Common.Dto;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Common;

/// <summary>
/// Team's **availability** model (when team is available to play).
/// </summary>
public class TeamAvailabilityModel :
    RangeLimitModel<TimeSpan?>,
    IMapFromReverse<TeamAvailabilityDto>
{
    /// <summary>
    /// Day of week.
    /// </summary>
    public DayOfWeek Day { get; set; }
}