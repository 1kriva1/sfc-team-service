using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Application.Interfaces.Persistence.Repository.Common.Data;
using SFC.Team.Domain.Common;

namespace SFC.Team.Application.Interfaces.Persistence.Repository.Data;
public interface IDataRepository<TEntity, TEnum> : IDataRepository<TEntity, IDataDbContext, TEnum>
    where TEntity : EnumDataEntity<TEnum>
    where TEnum : struct
{ }