using SFC.Team.Application.Interfaces.Persistence.Repository.Request.Data;
using SFC.Team.Domain.Entities.Request.Data;
using SFC.Team.Infrastructure.Persistence.Contexts;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Request.Data;
public class RequestStatusRepository(RequestDbContext context)
    : RequestDataRepository<RequestStatus, RequestStatusEnum>(context), IRequestStatusRepository
{ }