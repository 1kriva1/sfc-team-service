using AutoMapper;

using MassTransit;

using MediatR;

using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Team.Application.Interfaces.Team.Data;
using SFC.Team.Application.Interfaces.Team.Data.Models;
using SFC.Team.Infrastructure.Extensions;
using SFC.Team.Messages.Events.Team.Data;

namespace SFC.Team.Infrastructure.Services.Team.Data;
public class TeamDataService(
    IMapper mapper,
    IPublishEndpoint publisher,
    ITeamPlayerStatusRepository teamPlayerStatusesRepository,
    ITeamStatusRepository teamStatusesRepository) : ITeamDataService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly ITeamPlayerStatusRepository _teamPlayerStatusesRepository = teamPlayerStatusesRepository;
    private readonly ITeamStatusRepository _teamStatusesRepository = teamStatusesRepository;

    public async Task<GetAllTeamDataModel> GetAllTeamDataAsync()
    {
        return new()
        {
            TeamStatuses = await _teamStatusesRepository.ListAllAsync().ConfigureAwait(false),
            TeamPlayerStatuses = await _teamPlayerStatusesRepository.ListAllAsync().ConfigureAwait(false)
        };
    }

    public async Task<GetInviteDataModel> GetInviteDataAsync()
    {
        return new()
        {
            TeamPlayerStatuses = await _teamPlayerStatusesRepository.ListAllAsync().ConfigureAwait(false)
        };
    }

    public async Task<GetRequestDataModel> GetRequestDataAsync()
    {
        return new()
        {
            TeamPlayerStatuses = await _teamPlayerStatusesRepository.ListAllAsync().ConfigureAwait(false)
        };
    }

    public async Task<GetSchemeDataModel> GetSchemeDataAsync()
    {
        return new()
        {
            TeamPlayerStatuses = await _teamPlayerStatusesRepository.ListAllAsync().ConfigureAwait(false)
        };
    }

    public async Task PublishDataInitializedEventAsync(CancellationToken cancellationToken)
    {
        GetAllTeamDataModel model = await GetAllTeamDataAsync().ConfigureAwait(true);

        DataInitialized @event = _mapper.BuildTeamDataInitializedEvent(model);

        await _publisher.Publish(@event, cancellationToken)
                        .ConfigureAwait(false);
    }
}