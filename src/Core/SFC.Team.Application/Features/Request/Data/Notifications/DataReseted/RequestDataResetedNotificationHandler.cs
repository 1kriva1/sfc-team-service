using MediatR;

using SFC.Team.Application.Interfaces.Metadata;
using SFC.Team.Domain.Events.Request;

namespace SFC.Team.Application.Features.Request.Data.Notifications.DataReseted;
public class RequestDataResetedNotificationHandler(
    IMetadataService metadataService)
    : INotificationHandler<RequestDataResetedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;

    public async Task Handle(RequestDataResetedEvent notification, CancellationToken cancellationToken)
    {
        await _metadataService.CompleteAsync(MetadataServiceEnum.Request, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(false);
    }
}