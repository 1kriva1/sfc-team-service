using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Domain.Entities.Team.General;

namespace SFC.Team.Application.Features.Team.General.Common.Dto;
public class TeamAvailabilityDto : IMapFromReverse<TeamAvailability>
{
    public DayOfWeek Day { get; set; }

    public TimeSpan From { get; set; }

    public TimeSpan To { get; set; }
}