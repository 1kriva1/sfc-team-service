using SFC.Team.Domain.Common;

namespace SFC.Team.Application.Interfaces.Reference;
public interface IReference<TEntity, TId, TDto>
    where TEntity : BaseEntity<TId>
{
    Task<TEntity?> GetAsync(TId id, CancellationToken cancellationToken = default);
}