using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Team.Application.Common.Settings;
using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Infrastructure.Cache;
using SFC.Team.Infrastructure.Services.Cache;

namespace SFC.Team.Infrastructure.Extensions;
public static class CacheExtensions
{
    public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.Configure<CacheSettings>(configuration.GetSection(CacheSettings.SectionKey));
        services.AddScoped<ICache, RedisCache>();
        services.AddScoped<IRefreshCache, RefreshCacheService>();

        return services;
    }
}