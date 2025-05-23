using MediatR;

using SFC.Team.Application.Interfaces.Team.Player;
using SFC.Team.Domain.Events.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Notifications.TeamPlayerCreated;
public class TeamPlayerCreatedNotificationHandler(ITeamPlayerService teamPlayerService) : INotificationHandler<TeamPlayerCreatedEvent>
{
    private readonly ITeamPlayerService _teamPlayerService = teamPlayerService;

    public Task Handle(TeamPlayerCreatedEvent notification, CancellationToken cancellationToken)
    {
        return _teamPlayerService.NotifyTeamPlayerCreatedAsync(notification.TeamPlayer, cancellationToken);
    }
}