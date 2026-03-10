using AutoMapper;

using MassTransit;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using SFC.Team.Application.Common.Enums;
using SFC.Team.Application.Interfaces.Metadata;
using SFC.Team.Application.Interfaces.Team.Data;
using SFC.Team.Application.Interfaces.Team.Data.Models;
using SFC.Team.Infrastructure.Extensions;
using SFC.Team.Messages.Events.Team.Data;

namespace SFC.Team.Infrastructure.Services.Hosted;
public class DataInitializationHostedService(
    ILogger<DataInitializationHostedService> logger,
    IServiceProvider services) : BaseInitializationService(logger)
{
    private readonly IServiceProvider _services = services;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        EventId eventId = new((int)RequestId.InitData, Enum.GetName(RequestId.InitData));
        Action<ILogger, Exception?> logStartExecution = LoggerMessage.Define(LogLevel.Information, eventId,
            "Data Initialization Hosted Service running.");
        logStartExecution(Logger, null);

        using IServiceScope scope = _services.CreateScope();

        // publish team data
        await PublishDataInitializedAsync(scope, cancellationToken).ConfigureAwait(false);

        // send require data
        await SendRequireDataAsync(scope, cancellationToken).ConfigureAwait(false);
    }

    private static async Task PublishDataInitializedAsync(IServiceScope scope, CancellationToken cancellationToken)
    {
        ITeamDataService teamDataService = scope.ServiceProvider.GetRequiredService<ITeamDataService>();

        await teamDataService.PublishDataInitializedEventAsync(cancellationToken).ConfigureAwait(false);

        IMetadataService metadataService = scope.ServiceProvider.GetRequiredService<IMetadataService>();

        await metadataService.CompleteAsync(MetadataServiceEnum.Team, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(false);
    }

    private static Task SendRequireDataAsync(IServiceScope scope, CancellationToken cancellationToken)
    {
        // use bus because it is Initiator (reference to mass transit documentation)
        IBus bus = scope.ServiceProvider.GetRequiredService<IBus>();

        bus.Send(new SFC.Team.Messages.Commands.Data.RequireData(), cancellationToken);

        bus.Send(new SFC.Team.Messages.Commands.Invite.Data.RequireData(), cancellationToken);

        return bus.Send(new SFC.Team.Messages.Commands.Request.Data.RequireData(), cancellationToken);
    }
}