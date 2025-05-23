using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Infrastructure.Persistence.Contexts;
using SFC.Team.Infrastructure.Persistence.Extensions;
using SFC.Team.Infrastructure.Persistence.Interceptors;

namespace SFC.Team.Infrastructure.Persistence;
public static class PersistenceRegistration
{
    public static void AddPersistenceServices(this WebApplicationBuilder builder)
    {
        // contexts
        builder.Services.AddDbContext<MetadataDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<TeamDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<DataDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<IdentityDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<PlayerDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<InviteDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<RequestDbContext>(builder.Configuration, builder.Environment);

        // interceptors
        builder.Services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<DispatchDomainEventsSaveChangesInterceptor>();
        builder.Services.AddScoped<DataEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<UserEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<PlayerEntitySaveChangesInterceptor>();

        // contexts by interfaces
        builder.Services.AddScoped<IMetadataDbContext, MetadataDbContext>();
        builder.Services.AddScoped<ITeamDbContext, TeamDbContext>();
        builder.Services.AddScoped<IDataDbContext, DataDbContext>();
        builder.Services.AddScoped<IIdentityDbContext, IdentityDbContext>();
        builder.Services.AddScoped<IPlayerDbContext, PlayerDbContext>();
        builder.Services.AddScoped<IInviteDbContext, InviteDbContext>();
        builder.Services.AddScoped<IRequestDbContext, RequestDbContext>();

        // repositories
        builder.Services.AddRepositories(builder.Configuration);
    }
}