using SFC.Team.Api.Services;

namespace SFC.Team.Api.Infrastructure.Extensions;

public static class GrpcExtensions
{
    public static WebApplication UseGrpc(this WebApplication app)
    {
        app.MapGrpcService<TeamDataService>();
        app.MapGrpcService<TeamService>();
        app.MapGrpcService<TeamPlayerService>();

        return app;
    }
}