namespace SFC.Team.Application.Interfaces.Team.General;
public interface ITeamService
{
    Task NotifyTeamCreatedAsync(TeamEntity team, CancellationToken cancellationToken = default);

    Task NotifyTeamUpdatedAsync(TeamEntity team, CancellationToken cancellationToken = default);
}