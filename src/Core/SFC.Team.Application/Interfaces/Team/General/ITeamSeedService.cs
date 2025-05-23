namespace SFC.Team.Application.Interfaces.Team.General;
public interface ITeamSeedService
{
    Task<IEnumerable<TeamEntity>> GetSeedTeamsAsync();

    Task SeedTeamsAsync(CancellationToken cancellationToken = default);
}