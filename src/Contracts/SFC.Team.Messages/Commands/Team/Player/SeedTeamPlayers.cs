using SFC.Team.Messages.Commands.Common;
using SFC.Team.Messages.Models.Team.Player;

namespace SFC.Team.Messages.Commands.Team.Player;
public class SeedTeamPlayers : InitiatorCommand
{
    public IEnumerable<TeamPlayer> TeamPlayers { get; init; } = [];
}