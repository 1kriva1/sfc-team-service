using SFC.Team.Application.Features.Common.Models;
using SFC.Team.Application.Features.Common.Models.Find.Paging;
using SFC.Team.Application.Interfaces.Persistence.Context;

namespace SFC.Team.Application.Interfaces.Persistence.Repository.Common;
public interface IRepository<TEntity, TContext, TId>
    where TEntity : class
    where TContext : IDbContext
{
    Task<TEntity?> GetByIdAsync(TId id);

    Task<IReadOnlyList<TEntity>> ListAllAsync();

    Task<PagedList<TEntity>> FindAsync(FindParameters<TEntity> parameters);

    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity[]> AddRangeAsync(params TEntity[] entities);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
}