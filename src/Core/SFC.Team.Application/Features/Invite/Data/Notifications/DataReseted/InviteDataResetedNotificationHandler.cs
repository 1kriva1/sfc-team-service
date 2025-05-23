using MediatR;

using SFC.Team.Application.Interfaces.Metadata;
using SFC.Team.Domain.Events.Invite;

namespace SFC.Team.Application.Features.Invite.Data.Notifications.DataReseted;
public class InviteDataResetedNotificationHandler(IMetadataService metadataService)
    : INotificationHandler<InviteDataResetedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;

    public async Task Handle(InviteDataResetedEvent notification, CancellationToken cancellationToken)
    {
        await _metadataService.CompleteAsync(MetadataServiceEnum.Invite, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(false);
    }
}