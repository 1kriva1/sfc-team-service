using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Application.Interfaces.Team.Data;
using SFC.Team.Application.Interfaces.Team.Data.Models;

namespace SFC.Team.Infrastructure.Services.Cache;
public class RefreshCacheService(ICache cache, ITeamDataService dataService) : IRefreshCache
{
    private readonly ICache _cache = cache;
    private readonly ITeamDataService _dataService = dataService;

    public async Task RefreshAsync(CancellationToken token = default)
    {
        GetAllTeamDataModel model = await _dataService.GetAllTeamDataAsync().ConfigureAwait(false);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        RefreshAsync(model.TeamPlayerStatuses, token);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    }

    private Task RefreshAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _cache.DeleteAsync($"{typeof(T).Name}", cancellationToken);
        return _cache.SetAsync($"{typeof(T).Name}", entities, null, cancellationToken);
    }
}