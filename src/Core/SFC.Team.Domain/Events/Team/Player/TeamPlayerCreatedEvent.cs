using SFC.Team.Domain.Common;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Domain.Events.Team.Player;
public class TeamPlayerCreatedEvent(TeamPlayer teamPlayer) : BaseEvent
{
    public TeamPlayer TeamPlayer { get; } = teamPlayer;
}