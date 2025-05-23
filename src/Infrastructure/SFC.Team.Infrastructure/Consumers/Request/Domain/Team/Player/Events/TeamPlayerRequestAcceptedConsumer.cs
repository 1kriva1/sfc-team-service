using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;

using SFC.Request.Messages.Events.Request.Team.Player;
using SFC.Team.Application.Features.Team.Player.Commands.Create;
using SFC.Team.Domain.Enums.Request;
using SFC.Team.Infrastructure.Extensions;
using SFC.Team.Infrastructure.Settings.RabbitMq;

namespace SFC.Team.Infrastructure.Consumers.Request.Domain.Team.Player.Events;
public class TeamPlayerRequestAcceptedConsumer(IMapper mapper, ISender mediator) : IConsumer<TeamPlayerRequestUpdated>
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;

    public async Task Consume(ConsumeContext<TeamPlayerRequestUpdated> context)
    {
        TeamPlayerRequestUpdated @event = context.Message;

        CreateTeamPlayerCommand command = _mapper.Map<CreateTeamPlayerCommand>(@event);

        await _mediator.Send(command)
                       .ConfigureAwait(false);
    }
}

public class TeamPlayerRequestAcceptedDefinition : ConsumerDefinition<TeamPlayerRequestAcceptedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Request.Value.Domain.Team.Player.Events.Updated; } }

    public TeamPlayerRequestAcceptedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.team.request.team.player.accepted.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<TeamPlayerRequestAcceptedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, (Action<IRabbitMqExchangeToExchangeBindingConfigurator>)(x =>
            {
                x.AutoDelete = true;
                x.RoutingKey = Enum.GetName<SFC.Team.Domain.Enums.Request.RequestStatus>((RequestStatus)SFC.Team.Domain.Enums.Request.RequestStatus.Accepted);
                x.ExchangeType = Exchange.Type;
            }));
        }
    }
}