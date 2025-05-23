using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Team.Application.Interfaces.Team.Player;
using SFC.Team.Domain.Entities.Team.Player;
using SFC.Team.Infrastructure.Extensions;
using SFC.Team.Infrastructure.Settings.RabbitMq;
using SFC.Team.Messages.Commands.Team.Player;

namespace SFC.Team.Infrastructure.Consumers.Team.Domain.Player.Seed;
public class RequireTeamPlayersSeedConsumer(IMapper mapper, ITeamPlayerSeedService teamPlayerSeedService) : IConsumer<RequireTeamPlayersSeed>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerSeedService _teamPlayerSeedService = teamPlayerSeedService;

    public async Task Consume(ConsumeContext<RequireTeamPlayersSeed> context)
    {
        RequireTeamPlayersSeed message = context.Message;

        IEnumerable<TeamPlayer> teamPlayers = await _teamPlayerSeedService.GetSeedTeamPlayersAsync().ConfigureAwait(true);

        SeedTeamPlayers command = _mapper.Map<SeedTeamPlayers>(teamPlayers)
                                         .SetCommandInitiator(message.Initiator);

        await context.Publish(command).ConfigureAwait(false);
    }
}

public class RequireTeamPlayersSeedDefinition : ConsumerDefinition<RequireTeamPlayersSeedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Team.Value.Domain.Player.Seed.RequireSeed; } }

    public RequireTeamPlayersSeedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.team.players.seed.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireTeamPlayersSeedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.team.teams.seed.require"
            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}