using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Team.Application.Common.Settings;

namespace SFC.Team.Infrastructure.Extensions;
public static class RedisExtensions
{
    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        CacheSettings settings = configuration.GetCacheSettings();

        return services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = $"{settings.InstanceName}:";
        });
    }
}