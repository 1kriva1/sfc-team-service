using SFC.Team.Application.Interfaces.Persistence.Repository.Invite.Data;
using SFC.Team.Domain.Common;
using SFC.Team.Infrastructure.Persistence.Contexts;
using SFC.Team.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Invite.Data;
public class InviteDataRepository<TEntity, TEnum>(InviteDbContext context)
    : DataRepository<TEntity, InviteDbContext, TEnum>(context), IInviteDataRepository<TEntity, TEnum>
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }