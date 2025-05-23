using SFC.Team.Application.Interfaces.Persistence.Repository.Data;
using SFC.Team.Domain.Common;
using SFC.Team.Infrastructure.Persistence.Contexts;
using SFC.Team.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Data;
public class DataRepository<TEntity, TEnum>(DataDbContext context)
    : DataRepository<TEntity, DataDbContext, TEnum>(context), IDataRepository<TEntity, TEnum>
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{
}