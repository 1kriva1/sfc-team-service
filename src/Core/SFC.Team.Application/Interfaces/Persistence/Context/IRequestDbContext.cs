using SFC.Team.Domain.Entities.Request.Data;

namespace SFC.Team.Application.Interfaces.Persistence.Context;
public interface IRequestDbContext : IDbContext
{
    IQueryable<RequestStatus> RequestStatuses { get; }
}