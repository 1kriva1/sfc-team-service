using SFC.Team.Application.Features.Common.Dto.Common;

namespace SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;
public class GetTeamsAvailabilityLimitDto : RangeLimitDto<TimeSpan?>
{
    public IEnumerable<DayOfWeek> Days { get; set; } = [];
}