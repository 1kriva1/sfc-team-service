using SFC.Team.Messages.Models.Team.Player;

namespace SFC.Team.Messages.Events.Team.Player;
public class TeamPlayersSeeded
{
    public IEnumerable<TeamPlayer> TeamPlayers { get; init; } = [];
}