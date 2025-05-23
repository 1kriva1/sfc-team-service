using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Scheme.Messages.Commands.Team.Data;
using SFC.Team.Application.Interfaces.Team.Data;
using SFC.Team.Application.Interfaces.Team.Data.Models;
using SFC.Team.Infrastructure.Extensions;
using SFC.Team.Infrastructure.Settings.RabbitMq;

namespace SFC.Team.Infrastructure.Consumers.Scheme.Data;

public class RequireDataConsumer(IMapper mapper, ITeamDataService teamDataService)
    : IConsumer<RequireData>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamDataService _teamDataService = teamDataService;

    public async Task Consume(ConsumeContext<RequireData> context)
    {
        GetSchemeDataModel model = await _teamDataService.GetSchemeDataAsync().ConfigureAwait(true);

        InitializeData command = _mapper.BuildInitializeDataCommand(model);

        await context.Send(command).ConfigureAwait(false);
    }
}

public class RequireDataConsumerDefinition : ConsumerDefinition<RequireDataConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Scheme.Value.Data.Dependent.Team.RequireInitialize; } }

    public RequireDataConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.team.scheme.data.initialize.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireDataConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();
            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}