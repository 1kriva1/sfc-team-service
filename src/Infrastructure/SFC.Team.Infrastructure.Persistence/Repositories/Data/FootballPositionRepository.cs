using SFC.Team.Application.Interfaces.Persistence.Repository.Data;
using SFC.Team.Domain.Entities.Data;
using SFC.Team.Infrastructure.Persistence.Contexts;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Data;
public class FootballPositionRepository(DataDbContext context)
    : DataRepository<FootballPosition, FootballPositionEnum>(context), IFootballPositionRepository
{ }