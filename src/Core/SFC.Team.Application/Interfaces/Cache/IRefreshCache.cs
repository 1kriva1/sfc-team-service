namespace SFC.Team.Application.Interfaces.Cache;
public interface IRefreshCache
{
    Task RefreshAsync(CancellationToken token = default);
}