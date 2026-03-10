using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Team.Application.Common.Settings;
using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Infrastructure.Cache;
using SFC.Team.Infrastructure.Persistence.Constants;
using SFC.Team.Infrastructure.Services.Cache;

namespace SFC.Team.Infrastructure.Extensions;
public static class CacheExtensions
{
    public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CacheSettings>(configuration.GetSection(CacheSettings.SectionKey));

        services.AddScoped<ICache, RedisCache>();

        services.AddScoped<IRefreshCache, RefreshCacheService>();

        services.AddCacheInstance<RedisCache>(CacheInstance.Team, configuration);

        services.AddRelatedCacheInstances(configuration);

        return services;
    }

    private static void AddRelatedCacheInstances(this IServiceCollection services, IConfiguration configuration)
    {
        CacheSettings settings = configuration.GetCacheSettings();

        foreach (string relatedCache in settings.RelatedInstances)
        {
            services.AddRelatedCache(relatedCache, configuration);
        }
    }

    private static void AddRelatedCache(this IServiceCollection services, string instanceName, IConfiguration configuration)
    {
        switch (instanceName)
        {
            case CacheInstance.Data:
                services.AddCacheInstance<RedisDataCache>(CacheInstance.Data, configuration);
                break;
            case CacheInstance.Invite:
                services.AddCacheInstance<RedisInviteCache>(CacheInstance.Invite, configuration);
                break;
            case CacheInstance.Request:
                services.AddCacheInstance<RedisRequestCache>(CacheInstance.Request, configuration);
                break;
        }
    }

    private static void AddCacheInstance<T>(this IServiceCollection services, string instanceName, IConfiguration configuration)
        where T : class, ICache
    {
        services.AddKeyedScoped<ICache, T>(instanceName);

        services.AddKeyedSingleton<IDistributedCache>(instanceName,
            (services, _) => RedisExtensions.GetRedisCache(instanceName, configuration));
    }
}