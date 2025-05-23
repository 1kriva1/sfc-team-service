using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Invite.Messages.Events.Invite.Team.Player;
using SFC.Team.Application.Features.Team.Player.Commands.Create;
using SFC.Team.Domain.Enums.Invite;
using SFC.Team.Infrastructure.Extensions;
using SFC.Team.Infrastructure.Settings.RabbitMq;

namespace SFC.Team.Infrastructure.Consumers.Invite.Domain.Team.Player.Events;
public class TeamPlayerInviteAcceptedConsumer(IMapper mapper, ISender mediator) : IConsumer<TeamPlayerInviteUpdated>
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;

    public async Task Consume(ConsumeContext<TeamPlayerInviteUpdated> context)
    {
        TeamPlayerInviteUpdated @event = context.Message;

        CreateTeamPlayerCommand command = _mapper.Map<CreateTeamPlayerCommand>(@event);

        await _mediator.Send(command)
                       .ConfigureAwait(false);
    }
}

public class TeamPlayerInviteAcceptedDefinition : ConsumerDefinition<TeamPlayerInviteAcceptedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Invite.Value.Domain.Team.Player.Events.Updated; } }

    public TeamPlayerInviteAcceptedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.team.invite.team.player.accepted.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<TeamPlayerInviteAcceptedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.identity.team.player.updated"
            rmq.Bind(Exchange.Name, (Action<IRabbitMqExchangeToExchangeBindingConfigurator>)(x =>
            {
                x.AutoDelete = true;
                x.RoutingKey = Enum.GetName<SFC.Team.Domain.Enums.Invite.InviteStatus>((InviteStatus)SFC.Team.Domain.Enums.Invite.InviteStatus.Accepted);
                x.ExchangeType = Exchange.Type;
            }));
        }
    }
}