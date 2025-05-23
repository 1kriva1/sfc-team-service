using SFC.Team.Application;
using SFC.Team.Infrastructure;
using SFC.Team.Infrastructure.Constants;
using SFC.Team.Infrastructure.Persistence;

namespace SFC.Team.Api.Infrastructure.Extensions;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddApplicationServices();

        builder.AddPersistenceServices();

        builder.AddInfrastructureServices();

        builder.Services.AddApiServices();

        builder.Services.AddControllers();

        builder.Services.AddLocalization();

        builder.AddAuthentication();

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddSwagger();
        }

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        // global cors policy
        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders(CommonConstants.PaginationHeaderKey)
            .SetIsOriginAllowed(origin => true) // allow any origin
            .AllowCredentials());// allow credentials

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
        }

        app.UseHttpsRedirection();

        app.UseLocalization();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseCustomExceptionHandler();

        app.UseHangfireDashboard();

        app.MapControllers();

        app.UseGrpc();

        return app;
    }
}