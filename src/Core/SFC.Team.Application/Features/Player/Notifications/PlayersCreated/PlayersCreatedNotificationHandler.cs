using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Team.Application.Interfaces.Metadata;
using SFC.Team.Application.Interfaces.Team.Player;
using SFC.Team.Domain.Events.Player;

namespace SFC.Team.Application.Features.Player.Notifications.PlayersCreated;
public class PlayersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    ITeamPlayerSeedService teamPlayerSeedService) : INotificationHandler<PlayersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly ITeamPlayerSeedService _teamPlayerSeedService = teamPlayerSeedService;

    public async Task Handle(PlayersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Player, MetadataDomainEnum.Player, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (await _metadataService.IsCompletedAsync(MetadataServiceEnum.Team, MetadataDomainEnum.Team, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Team, MetadataDomainEnum.TeamPlayer, MetadataTypeEnum.Seed).ConfigureAwait(true))
                {
                    // seed team players
                    await _teamPlayerSeedService.SeedTeamPlayersAsync(cancellationToken).ConfigureAwait(false);
                }
            }
        }
    }
}