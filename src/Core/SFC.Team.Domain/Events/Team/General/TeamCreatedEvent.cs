using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Events.Team.General;
public class TeamCreatedEvent(TeamEntity team) : BaseEvent
{
    public TeamEntity Team { get; } = team;
}