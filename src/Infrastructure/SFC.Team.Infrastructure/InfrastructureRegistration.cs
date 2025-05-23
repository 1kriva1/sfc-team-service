using System.Reflection;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using SFC.Team.Application.Interfaces.Common;
using SFC.Team.Application.Interfaces.Identity;
using SFC.Team.Application.Interfaces.Metadata;
using SFC.Team.Application.Interfaces.Player;
using SFC.Team.Application.Interfaces.Reference;
using SFC.Team.Application.Interfaces.Team.Data;
using SFC.Team.Application.Interfaces.Team.General;
using SFC.Team.Application.Interfaces.Team.Player;
using SFC.Team.Infrastructure.Authorization.OwnPlayer;
using SFC.Team.Infrastructure.Authorization.OwnTeam;
using SFC.Team.Infrastructure.Extensions;
using SFC.Team.Infrastructure.Extensions.Grpc;
using SFC.Team.Infrastructure.Services.Common;
using SFC.Team.Infrastructure.Services.Hosted;
using SFC.Team.Infrastructure.Services.Identity;
using SFC.Team.Infrastructure.Services.Metadata;
using SFC.Team.Infrastructure.Services.Player;
using SFC.Team.Infrastructure.Services.Reference;
using SFC.Team.Infrastructure.Services.Team.Data;
using SFC.Team.Infrastructure.Services.Team.General;
using SFC.Team.Infrastructure.Services.Team.Player;

namespace SFC.Team.Infrastructure;
public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        builder.Services.AddHangfire(builder.Configuration);

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAccessTokenManagement();

        builder.Services.AddRedis(builder.Configuration);

        builder.AddMassTransit();

        builder.Services.AddCache(builder.Configuration);

        builder.Services.AddGrpc(builder.Configuration, builder.Environment);

        builder.Services.AddSingleton<IUriService>(o =>
        {
            IHttpContextAccessor accessor = o.GetRequiredService<IHttpContextAccessor>();
            HttpRequest request = accessor.HttpContext!.Request;
            return new UriService(string.Concat(request.Scheme, "://", request.Host.ToUriComponent()));
        });

        // custom services
        builder.Services.AddTransient<IMetadataService, MetadataService>();
        builder.Services.AddTransient<IDateTimeService, DateTimeService>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IUserSeedService, UserSeedService>();
        builder.Services.AddTransient<IPlayerSeedService, PlayerSeedService>();
        builder.Services.AddTransient<ITeamDataService, TeamDataService>();
        builder.Services.AddTransient<ITeamService, TeamService>();
        builder.Services.AddTransient<ITeamSeedService, TeamSeedService>();
        builder.Services.AddTransient<ITeamPlayerService, TeamPlayerService>();
        builder.Services.AddTransient<ITeamPlayerSeedService, TeamPlayerSeedService>();

        // grpc
        builder.Services.AddTransient<IIdentityService, IdentityService>();
        builder.Services.AddTransient<IPlayerService, PlayerService>();

        // references
        builder.Services.AddScoped<IIdentityReference, IdentityReference>();
        builder.Services.AddScoped<IPlayerReference, PlayerReference>();

        // hosted services
        builder.Services.AddHostedService<DatabaseResetHostedService>();
        builder.Services.AddHostedService<DataInitializationHostedService>();
        builder.Services.AddHostedService<JobsInitializationHostedService>();

        // authorization
        builder.Services.AddScoped<IAuthorizationHandler, OwnTeamHandler>();
        builder.Services.AddScoped<IAuthorizationHandler, OwnPlayerHandler>();
    }
}