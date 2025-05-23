using MediatR;

using SFC.Team.Application.Interfaces.Team.General;
using SFC.Team.Domain.Events.Team.General;

namespace SFC.Team.Application.Features.Team.General.Notifications.TeamCreated;
public class TeamCreatedNotificationHandler(ITeamService teamService) : INotificationHandler<TeamCreatedEvent>
{
    private readonly ITeamService _teamService = teamService;

    public Task Handle(TeamCreatedEvent notification, CancellationToken cancellationToken)
    {
        return _teamService.NotifyTeamCreatedAsync(notification.Team, cancellationToken);
    }
}