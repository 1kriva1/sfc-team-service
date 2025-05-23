using System.Reflection;

using MassTransit;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SFC.Identity.Messages.Commands.User;
using SFC.Player.Messages.Commands.Player;
using SFC.Team.Infrastructure.Settings.RabbitMq;
using SFC.Team.Messages.Commands.Common;
using SFC.Team.Messages.Commands.Team.General;
using SFC.Team.Messages.Commands.Team.Player;
using SFC.Team.Messages.Events.Team.Data;
using SFC.Team.Messages.Events.Team.General;
using SFC.Team.Messages.Events.Team.Player;

namespace SFC.Team.Infrastructure.Extensions;
public static class MassTransitExtensions
{
    private const string EXCHANGE_ENDPOINT_SHORT_ADDRESS = "exchange";
    private const string EXCHANGE_ENDPOINT_AUTO_DELETE_PART = "autodelete";

    #region Public

    public static IServiceCollection AddMassTransit(this WebApplicationBuilder builder)
    {
        return builder.Services.AddMassTransit(masTransitConfigure =>
        {
            masTransitConfigure.AddConsumers(Assembly.GetExecutingAssembly());

            masTransitConfigure.UsingRabbitMq((context, rabbitMqConfigure) =>
            {
                RabbitMqSettings settings = builder.Configuration.GetRabbitMqSettings();

                string rabbitMqConnectionString = builder.Configuration.GetConnectionString("RabbitMq")!;

                rabbitMqConfigure.Host(new Uri(rabbitMqConnectionString), settings.Name, h =>
                {
                    h.Username(settings.Username);
                    h.Password(settings.Password);
                });

                rabbitMqConfigure.UseRetries(settings.Retry);

                rabbitMqConfigure.AddExchanges(builder.Environment, settings.Exchanges);

                rabbitMqConfigure.ConfigureEndpoints(context);

                MapEndpoints(settings.Exchanges, builder.Environment);
            });
        });
    }

    public static string BuildExchangeRoutingKey(this string initiator, string key)
        => $"{key.ToLower(System.Globalization.CultureInfo.CurrentCulture)}.{initiator.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)}";

    #endregion Public

    #region Private

    private static void MapEndpoints(RabbitMqExchangesSettings exchangesSettings, IWebHostEnvironment environment)
    {
        EndpointConvention.Map<SFC.Team.Messages.Commands.Data.RequireData>(exchangesSettings.Team.Value.Data.Dependent.Data.RequireInitialize.GetExchangeEndpointUri());

        EndpointConvention.Map<Team.Messages.Commands.Invite.Data.RequireData>(exchangesSettings.Team.Value.Data.Dependent.Invite.RequireInitialize.GetExchangeEndpointUri());

        EndpointConvention.Map<Team.Messages.Commands.Request.Data.RequireData>(exchangesSettings.Team.Value.Data.Dependent.Request.RequireInitialize.GetExchangeEndpointUri());

        EndpointConvention.Map<SFC.Invite.Messages.Commands.Team.Data.InitializeData>(exchangesSettings.Invite.Value.Data.Dependent.Team.Initialize.GetExchangeEndpointUri());

        EndpointConvention.Map<SFC.Request.Messages.Commands.Team.Data.InitializeData>(exchangesSettings.Request.Value.Data.Dependent.Team.Initialize.GetExchangeEndpointUri());

        EndpointConvention.Map<SFC.Scheme.Messages.Commands.Team.Data.InitializeData>(exchangesSettings.Scheme.Value.Data.Dependent.Team.Initialize.GetExchangeEndpointUri());

        if (environment.IsDevelopment())
        {
            // "sfc.identity.users.seed.require"
            EndpointConvention.Map<RequireUsersSeed>(exchangesSettings.Identity.Value.Domain.User.Seed.RequireSeed.GetExchangeEndpointUri());

            // "sfc.player.players.seed.require"
            EndpointConvention.Map<RequirePlayersSeed>(exchangesSettings.Player.Value.Domain.Player.Seed.RequireSeed.GetExchangeEndpointUri());
        }
    }

    private static void AddExchanges(
        this IRabbitMqBusFactoryConfigurator configure,
        IWebHostEnvironment environment,
        RabbitMqExchangesSettings exchangesSettings)
    {
        // "sfc.team.data.initialized"
        configure.AddExchange<DataInitialized>(exchangesSettings.Team.Value.Data.Source.Initialized);

        // "sfc.team.created"
        configure.AddExchange<TeamCreated>(exchangesSettings.Team.Value.Domain.Team.Events.Created);

        // "sfc.team.updated"
        configure.AddExchange<TeamUpdated>(exchangesSettings.Team.Value.Domain.Team.Events.Updated);

        // "sfc.team.player.created"
        configure.AddExchange<TeamPlayerCreated>(exchangesSettings.Team.Value.Domain.Player.Events.Created);

        // "sfc.team.player.removed"
        configure.AddExchange<TeamPlayerUpdated>(exchangesSettings.Team.Value.Domain.Player.Events.Updated);

        if (environment.IsDevelopment())
        {
            // "sfc.team.teams.seed"
            configure.AddExchange<SeedTeams>(exchangesSettings.Team.Value.Domain.Team.Seed.Seed, exchangesSettings.Team.Key);

            // "sfc.team.teams.seeded"
            configure.AddExchange<TeamsSeeded>(exchangesSettings.Team.Value.Domain.Team.Seed.Seeded);

            // "sfc.team.players.seed"
            configure.AddExchange<SeedTeamPlayers>(exchangesSettings.Team.Value.Domain.Player.Seed.Seed, exchangesSettings.Team.Key);

            // "sfc.team.players.seeded"
            configure.AddExchange<TeamPlayersSeeded>(exchangesSettings.Team.Value.Domain.Player.Seed.Seeded);

            // exclude base command
            configure.Publish<InitiatorCommand>(p => p.Exclude = true);
        }
    }

    private static void UseRetries(this IRabbitMqBusFactoryConfigurator configure, RabbitMqRetrySettings settings)
    {
        configure.UseDelayedRedelivery(r =>
            r.Intervals(settings.Intervals.Select(i => TimeSpan.FromMinutes(i)).ToArray()));
        configure.UseMessageRetry(r => r.Immediate(settings.Limit));
    }

    private static void AddExchange<T>(this IRabbitMqBusFactoryConfigurator configure, Exchange exchange) where T : class
    {
        configure.Message<T>(x => x.SetEntityName(exchange.Name));
        configure.Publish<T>(x =>
        {
            x.AutoDelete = true;
            x.ExchangeType = exchange.Type;
        });
    }

    private static void AddExchange<T>(this IRabbitMqBusFactoryConfigurator configure, Exchange exchange, string key)
        where T : InitiatorCommand
    {
        configure.Message<T>(x => x.SetEntityName(exchange.Name));
        configure.Send<T>(x => x.UseRoutingKeyFormatter(context => context.Message.Initiator.BuildExchangeRoutingKey(key)));
        configure.Publish<T>(x =>
        {
            x.AutoDelete = true;
            x.ExchangeType = exchange.Type;
        });
    }

    private static Uri GetExchangeEndpointUri(this Message exchange) =>
       new($"{EXCHANGE_ENDPOINT_SHORT_ADDRESS}:{exchange.Name}?{EXCHANGE_ENDPOINT_AUTO_DELETE_PART}={true}");

    #endregion Private
}