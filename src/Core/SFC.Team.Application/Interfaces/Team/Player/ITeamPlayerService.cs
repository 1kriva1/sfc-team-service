using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Interfaces.Team.Player;
public interface ITeamPlayerService
{
    Task NotifyTeamPlayerCreatedAsync(TeamPlayer teamPlayer, CancellationToken cancellationToken = default);

    Task NotifyTeamPlayerUpdatedAsync(TeamPlayer teamPlayer, CancellationToken cancellationToken = default);
}