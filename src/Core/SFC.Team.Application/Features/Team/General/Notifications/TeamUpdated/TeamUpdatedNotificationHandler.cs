using MediatR;

using SFC.Team.Application.Interfaces.Team.General;
using SFC.Team.Domain.Events.Team.General;

namespace SFC.Team.Application.Features.Team.General.Notifications.TeamUpdated;
public class TeamUpdatedNotificationHandler(ITeamService teamService) : INotificationHandler<TeamUpdatedEvent>
{
    private readonly ITeamService _teamService = teamService;

    public Task Handle(TeamUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return _teamService.NotifyTeamUpdatedAsync(notification.Team, cancellationToken);
    }
}