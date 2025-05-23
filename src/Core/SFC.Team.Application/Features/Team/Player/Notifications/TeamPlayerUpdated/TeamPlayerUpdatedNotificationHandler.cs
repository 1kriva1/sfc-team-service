using MediatR;

using SFC.Team.Application.Interfaces.Team.Player;
using SFC.Team.Domain.Events.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Notifications.TeamPlayerUpdated;
public class TeamPlayerUpdatedNotificationHandler(ITeamPlayerService teamPlayerService) : INotificationHandler<TeamPlayerUpdatedEvent>
{
    private readonly ITeamPlayerService _teamPlayerService = teamPlayerService;

    public Task Handle(TeamPlayerUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return _teamPlayerService.NotifyTeamPlayerUpdatedAsync(notification.TeamPlayer, cancellationToken);
    }
}