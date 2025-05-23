using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Interfaces.Team.Player;
public interface ITeamPlayerSeedService
{
    Task<IEnumerable<TeamPlayer>> GetSeedTeamPlayersAsync();

    Task SeedTeamPlayersAsync(CancellationToken cancellationToken = default);
}