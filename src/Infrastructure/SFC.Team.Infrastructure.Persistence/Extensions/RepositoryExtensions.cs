using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Team.Application.Common.Settings;
using SFC.Team.Application.Interfaces.Persistence.Repository.Common;
using SFC.Team.Application.Interfaces.Persistence.Repository.Data;
using SFC.Team.Application.Interfaces.Persistence.Repository.Identity.General;
using SFC.Team.Application.Interfaces.Persistence.Repository.Invite.Data;
using SFC.Team.Application.Interfaces.Persistence.Repository.Metadata;
using SFC.Team.Application.Interfaces.Persistence.Repository.Player.General;
using SFC.Team.Application.Interfaces.Persistence.Repository.Request.Data;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Team.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Team.Infrastructure.Persistence.Repositories.Common;
using SFC.Team.Infrastructure.Persistence.Repositories.Data;
using SFC.Team.Infrastructure.Persistence.Repositories.Data.Cache;
using SFC.Team.Infrastructure.Persistence.Repositories.Identity;
using SFC.Team.Infrastructure.Persistence.Repositories.Invite.Data;
using SFC.Team.Infrastructure.Persistence.Repositories.Invite.Data.Cache;
using SFC.Team.Infrastructure.Persistence.Repositories.Metadata;
using SFC.Team.Infrastructure.Persistence.Repositories.Player;
using SFC.Team.Infrastructure.Persistence.Repositories.Request.Data;
using SFC.Team.Infrastructure.Persistence.Repositories.Request.Data.Cache;
using SFC.Team.Infrastructure.Persistence.Repositories.Team.Data;
using SFC.Team.Infrastructure.Persistence.Repositories.Team.Data.Cache;
using SFC.Team.Infrastructure.Persistence.Repositories.Team.General;
using SFC.Team.Infrastructure.Persistence.Repositories.Team.Player;

namespace SFC.Team.Infrastructure.Persistence.Extensions;
public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
        services.AddScoped<IMetadataRepository, MetadataRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<ITeamPlayerRepository, TeamPlayerRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPlayerRepository, PlayerRepository>();

        CacheSettings? cacheSettings = configuration
           .GetSection(CacheSettings.SectionKey)
           .Get<CacheSettings>();

        if (cacheSettings?.Enabled ?? false)
        {
            // data
            services.AddScoped<FootballPositionRepository>();
            services.AddScoped<IFootballPositionRepository, FootballPositionCacheRepository>();
            services.AddScoped<GameStyleRepository>();
            services.AddScoped<IGameStyleRepository, GameStyleCacheRepository>();
            services.AddScoped<ShirtRepository>();
            services.AddScoped<IShirtRepository, ShirtCacheRepository>();
            services.AddScoped<StatCategoryRepository>();
            services.AddScoped<IStatCategoryRepository, StatCategoryCacheRepository>();
            services.AddScoped<StatSkillRepository>();
            services.AddScoped<IStatSkillRepository, StatSkillCacheRepository>();
            services.AddScoped<StatTypeRepository>();
            services.AddScoped<IStatTypeRepository, StatTypeCacheRepository>();
            services.AddScoped<WorkingFootRepository>();
            services.AddScoped<IWorkingFootRepository, WorkingFootCacheRepository>();

            // invite
            services.AddScoped<InviteStatusRepository>();
            services.AddScoped<IInviteStatusRepository, InviteStatusCacheRepository>();

            // request
            services.AddScoped<RequestStatusRepository>();
            services.AddScoped<IRequestStatusRepository, RequestStatusCacheRepository>();

            // team
            services.AddScoped<TeamPlayerStatusRepository>();
            services.AddScoped<ITeamPlayerStatusRepository, TeamPlayerStatusCacheRepository>();
        }
        else
        {
            // data
            services.AddScoped<IFootballPositionRepository, FootballPositionRepository>();
            services.AddScoped<IGameStyleRepository, GameStyleRepository>();
            services.AddScoped<IRequestStatusRepository, RequestStatusRepository>();
            services.AddScoped<IShirtRepository, ShirtRepository>();
            services.AddScoped<IStatCategoryRepository, StatCategoryRepository>();
            services.AddScoped<IStatSkillRepository, StatSkillRepository>();
            services.AddScoped<IStatTypeRepository, StatTypeRepository>();
            services.AddScoped<IWorkingFootRepository, WorkingFootRepository>();

            // invite
            services.AddScoped<IInviteStatusRepository, InviteStatusRepository>();

            // request
            services.AddScoped<IRequestStatusRepository, RequestStatusRepository>();

            // team
            services.AddScoped<ITeamPlayerStatusRepository, TeamPlayerStatusRepository>();
        }

        return services;
    }
}