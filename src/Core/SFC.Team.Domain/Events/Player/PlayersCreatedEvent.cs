using SFC.Team.Domain.Common;
using SFC.Team.Domain.Entities.Player;

namespace SFC.Team.Domain.Events.Player;
public class PlayersCreatedEvent(IEnumerable<PlayerEntity> players) : BaseEvent
{
    public IEnumerable<PlayerEntity> Players { get; } = players;
}