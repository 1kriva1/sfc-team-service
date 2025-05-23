using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Application.Interfaces.Persistence.Repository.Common.Data;
using SFC.Team.Domain.Common;

namespace SFC.Team.Application.Interfaces.Persistence.Repository.Team.Data;
public interface ITeamDataRepository<T, TEnum> : IDataRepository<T, ITeamDbContext, TEnum>
    where T : EnumDataEntity<TEnum>
    where TEnum : struct
{
}