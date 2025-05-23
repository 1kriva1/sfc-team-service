namespace SFC.Team.Application.Interfaces.Identity;
public interface IUserSeedService
{
    Task SendRequireUsersSeedAsync(CancellationToken cancellationToken = default);
}