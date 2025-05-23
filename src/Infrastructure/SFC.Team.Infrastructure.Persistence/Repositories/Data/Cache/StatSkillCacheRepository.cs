using SFC.Team.Application.Interfaces.Cache;
using SFC.Team.Application.Interfaces.Persistence.Repository.Data;
using SFC.Team.Domain.Entities.Data;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Data.Cache;
public class StatSkillCacheRepository(StatSkillRepository repository, ICache cache)
    : DataCacheRepository<StatSkill, StatSkillEnum>(repository, cache), IStatSkillRepository
{ }