using SFC.Team.Api.Services;
using SFC.Team.Infrastructure.Constants;
using SFC.Team.Infrastructure.Extensions;
using SFC.Team.Infrastructure.Settings;

using TeamPlayerService = SFC.Team.Api.Services.TeamPlayerService;
using TeamService = SFC.Team.Api.Services.TeamService;

namespace SFC.Team.Api.Infrastructure.Extensions;

public static class GrpcExtensions
{
    public static WebApplication UseGrpc(this WebApplication app)
    {
        KestrelSettings settings = app.Configuration.GetKestrelSettings();

        if (settings?.Endpoints?.TryGetValue(SettingConstants.KestrelInternalEndpoint, out KestrelEndpointSettings? endpoint) ?? false)
        {
            app.MapGrpcService<TeamDataService>()
               .MapInternalService(endpoint.Url);
            app.MapGrpcService<TeamService>()
               .MapInternalService(endpoint.Url);
            app.MapGrpcService<TeamPlayerService>()
               .MapInternalService(endpoint.Url);
        }
        else
        {
            app.MapGrpcService<TeamDataService>();
            app.MapGrpcService<TeamService>();
            app.MapGrpcService<TeamPlayerService>();
        }

        return app;
    }

    /// <summary>
    /// Without RequireHost WebApi and Grpc not working together
    /// RequireHost distinguish webapi and grpc by port value
    /// Also required Kestrel endpoint configuration in appSettings
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="url"></param>
    private static void MapInternalService(this GrpcServiceEndpointConventionBuilder builder, string url)
        => builder.RequireHost($"*:{new Uri(url).Port}");
}