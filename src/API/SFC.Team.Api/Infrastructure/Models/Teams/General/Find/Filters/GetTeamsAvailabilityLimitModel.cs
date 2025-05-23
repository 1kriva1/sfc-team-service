using SFC.Team.Api.Infrastructure.Models.Common;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Find.Filters;

/// <summary>
/// Get teams **availability filter** model.
/// </summary>
public class GetTeamsAvailabilityLimitModel :
    RangeLimitModel<TimeSpan?>,
    IMapTo<GetTeamsAvailabilityLimitDto>
{
    /// <summary>
    /// Days of week.
    /// </summary>
    public IEnumerable<int>? Days { get; set; }
}