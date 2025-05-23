using SFC.Team.Application.Interfaces.Persistence.Repository.Request.Data;
using SFC.Team.Domain.Common;
using SFC.Team.Infrastructure.Persistence.Contexts;
using SFC.Team.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Request.Data;
public class RequestDataRepository<TEntity, TEnum>(RequestDbContext context)
    : DataRepository<TEntity, RequestDbContext, TEnum>(context), IRequestDataRepository<TEntity, TEnum>
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }