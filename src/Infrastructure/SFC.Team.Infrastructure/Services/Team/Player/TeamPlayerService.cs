using AutoMapper;

using MassTransit;

using SFC.Team.Application.Interfaces.Team.Player;
using SFC.Team.Domain.Entities.Team.Player;
using SFC.Team.Messages.Events.Team.Player;

namespace SFC.Team.Infrastructure.Services.Team.Player;
public class TeamPlayerService(IMapper mapper, IPublishEndpoint publisher) : ITeamPlayerService
{
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IMapper _mapper = mapper;

    public Task NotifyTeamPlayerCreatedAsync(TeamPlayer teamPlayer, CancellationToken cancellationToken = default)
    {
        TeamPlayerCreated @event = _mapper.Map<TeamPlayerCreated>(teamPlayer);
        return _publisher.Publish(@event, cancellationToken);
    }

    public Task NotifyTeamPlayerUpdatedAsync(TeamPlayer teamPlayer, CancellationToken cancellationToken = default)
    {
        TeamPlayerUpdated @event = _mapper.Map<TeamPlayerUpdated>(teamPlayer);
        return _publisher.Publish(@event, cancellationToken);
    }
}