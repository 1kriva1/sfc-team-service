using SFC.Team.Application.Features.Common.Dto.Common;

namespace SFC.Team.Application.Common.Dto.Player.Filters;
public class PlayerAvailabilityLimitFilterDto : RangeLimitDto<TimeSpan?>
{
    public IEnumerable<DayOfWeek> Days { get; set; } = [];
}