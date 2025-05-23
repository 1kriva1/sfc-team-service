using SFC.Team.Messages.Commands.Common;

namespace SFC.Team.Messages.Commands.Team.General;
public class SeedTeams : InitiatorCommand
{
    public IEnumerable<TeamEntity> Teams { get; init; } = [];
}