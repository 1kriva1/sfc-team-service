namespace SFC.Team.Application.Interfaces.Persistence.Context;
public interface IDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}