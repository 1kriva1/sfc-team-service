using SFC.Team.Domain.Entities.Invite.Data;

namespace SFC.Team.Application.Interfaces.Persistence.Context;
public interface IInviteDbContext : IDbContext
{
    IQueryable<InviteStatus> InviteStatuses { get; }
}