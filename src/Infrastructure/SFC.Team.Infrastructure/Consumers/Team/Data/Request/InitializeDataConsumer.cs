using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;

using SFC.Team.Application.Features.Request.Data.Commands.Reset;
using SFC.Team.Infrastructure.Extensions;
using SFC.Team.Infrastructure.Settings.RabbitMq;
using SFC.Team.Messages.Commands.Request.Data;

namespace SFC.Team.Infrastructure.Consumers.Team.Data.Request;
public class InitializeDataConsumer(IMapper mapper, ISender mediator) : IConsumer<InitializeData>
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;

    public async Task Consume(ConsumeContext<InitializeData> context)
    {
        InitializeData message = context.Message;

        ResetRequestDataCommand command = _mapper.Map<ResetRequestDataCommand>(message);

        await _mediator.Send(command)
                       .ConfigureAwait(false);
    }
}

public class RequireDataConsumerDefinition : ConsumerDefinition<InitializeDataConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Team.Value.Data.Dependent.Request.Initialize; } }

    public RequireDataConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.team.request.data.initialize.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<InitializeDataConsumer> consumerConfigurator, IRegistrationContext context)
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