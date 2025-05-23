using SFC.Team.Application.Interfaces.Persistence.Repository.Invite.Data;
using SFC.Team.Domain.Entities.Invite.Data;
using SFC.Team.Infrastructure.Persistence.Contexts;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Invite.Data;
public class InviteStatusRepository(InviteDbContext context)
    : InviteDataRepository<InviteStatus, InviteStatusEnum>(context), IInviteStatusRepository
{ }