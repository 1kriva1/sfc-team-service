using SFC.Team.Domain.Entities.Invite.Data;
using SFC.Team.Domain.Entities.Request.Data;

namespace SFC.Team.Application.Interfaces.Persistence.Repository.Request.Data;
public interface IRequestStatusRepository : IRequestDataRepository<RequestStatus, RequestStatusEnum> { }