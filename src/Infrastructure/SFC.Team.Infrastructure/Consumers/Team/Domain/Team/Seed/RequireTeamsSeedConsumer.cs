using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Team.Application.Interfaces.Team.General;
using SFC.Team.Infrastructure.Extensions;
using SFC.Team.Infrastructure.Settings.RabbitMq;
using SFC.Team.Messages.Commands.Team.General;

namespace SFC.Team.Infrastructure.Consumers.Team.Domain.Team.Seed;
public class RequireTeamsSeedConsumer(IMapper mapper, ITeamSeedService teamSeedService) : IConsumer<RequireTeamsSeed>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamSeedService _teamSeedService = teamSeedService;

    public async Task Consume(ConsumeContext<RequireTeamsSeed> context)
    {
        RequireTeamsSeed message = context.Message;

        IEnumerable<TeamEntity> teams = await _teamSeedService.GetSeedTeamsAsync().ConfigureAwait(true);

        SeedTeams command = _mapper.Map<SeedTeams>(teams)
                                   .SetCommandInitiator(message.Initiator);

        await context.Publish(command).ConfigureAwait(false);
    }
}

public class RequireTeamsSeedDefinition : ConsumerDefinition<RequireTeamsSeedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Team.Value.Domain.Team.Seed.RequireSeed; } }

    public RequireTeamsSeedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.team.teams.seed.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireTeamsSeedConsumer> consumerConfigurator,
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