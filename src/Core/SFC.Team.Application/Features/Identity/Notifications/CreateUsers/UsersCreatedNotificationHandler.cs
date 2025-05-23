using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Team.Application.Interfaces.Metadata;
using SFC.Team.Application.Interfaces.Player;
using SFC.Team.Application.Interfaces.Team.General;
using SFC.Team.Domain.Events.Identity;

namespace SFC.Team.Application.Features.Identity.Notifications.CreateUsers;
public class UsersCreatedNotificationHandler(
    IPlayerSeedService playerSeedService,
    ITeamSeedService teamSeedService,
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment) : INotificationHandler<UsersCreatedEvent>
{
    private readonly IPlayerSeedService _playerSeedService = playerSeedService;
    private readonly ITeamSeedService _teamSeedService = teamSeedService;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;

    public async Task Handle(UsersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Identity, MetadataDomainEnum.User, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (await _metadataService.IsCompletedAsync(MetadataServiceEnum.Data, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(true))
            {
                if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Player, MetadataDomainEnum.Player, MetadataTypeEnum.Seed).ConfigureAwait(true))
                {
                    await _playerSeedService.SendRequirePlayersSeedAsync(cancellationToken)
                                    .ConfigureAwait(false);
                }

                if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Team, MetadataDomainEnum.Team, MetadataTypeEnum.Seed).ConfigureAwait(true))
                {
                    // seed teams
                    await _teamSeedService.SeedTeamsAsync(cancellationToken).ConfigureAwait(false);
                }
            }
        }
    }
}