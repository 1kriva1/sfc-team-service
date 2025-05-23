using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Team.Application.Interfaces.Identity;
using SFC.Team.Application.Interfaces.Metadata;
using SFC.Team.Domain.Enums.Metadata;
using SFC.Team.Domain.Events.Data;

namespace SFC.Team.Application.Features.Data.Notifications.DataReseted;
public class DataResetedNotificationHandler(
    IHostEnvironment hostEnvironment,
    IUserSeedService userSeedService,
    IMetadataService metadataService)
    : INotificationHandler<DataResetedEvent>
{
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IUserSeedService _userSeedService = userSeedService;
    private readonly IMetadataService _metadataService = metadataService;

    public async Task Handle(DataResetedEvent notification, CancellationToken cancellationToken)
    {
        await _metadataService.CompleteAsync(MetadataService.Data, MetadataDomainEnum.Data, MetadataType.Initialization).ConfigureAwait(false);

        if (_hostEnvironment.IsDevelopment())
        {
            // require seed users
            await _userSeedService.SendRequireUsersSeedAsync(cancellationToken)
                                  .ConfigureAwait(false);
        }
    }
}