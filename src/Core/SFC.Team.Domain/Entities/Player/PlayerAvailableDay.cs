using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Entities.Player;
public class PlayerAvailableDay : BaseEntity<long>
{
    public PlayerAvailability Availability { get; set; } = null!;

    public DayOfWeek Day { get; set; }
}