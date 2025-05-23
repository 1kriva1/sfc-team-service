using AutoMapper;

using MassTransit;

using SFC.Team.Application.Interfaces.Team.General;
using SFC.Team.Messages.Events.Team.General;

namespace SFC.Team.Infrastructure.Services.Team.General;
public class TeamService(IMapper mapper, IPublishEndpoint publisher) : ITeamService
{
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IMapper _mapper = mapper;

    public Task NotifyTeamCreatedAsync(TeamEntity team, CancellationToken cancellationToken = default)
    {
        TeamCreated @event = _mapper.Map<TeamCreated>(team);
        return _publisher.Publish(@event, cancellationToken);
    }

    public Task NotifyTeamUpdatedAsync(TeamEntity team, CancellationToken cancellationToken = default)
    {
        TeamUpdated @event = _mapper.Map<TeamUpdated>(team);
        return _publisher.Publish(@event, cancellationToken);
    }
}