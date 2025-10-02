using SFC.Team.Domain.Entities.Team.Data;

namespace SFC.Team.Application.Interfaces.Persistence.Repository.Team.Data;
public interface ITeamStatusRepository : ITeamDataRepository<TeamStatus, TeamStatusEnum> { }