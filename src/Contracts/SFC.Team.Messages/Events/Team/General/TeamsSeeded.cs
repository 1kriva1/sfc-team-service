namespace SFC.Team.Messages.Events.Team.General;
public class TeamsSeeded
{
    public IEnumerable<TeamEntity> Teams { get; init; } = [];
}