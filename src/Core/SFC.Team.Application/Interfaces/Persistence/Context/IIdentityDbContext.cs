using SFC.Team.Domain.Entities.Identity;

namespace SFC.Team.Application.Interfaces.Persistence.Context;
public interface IIdentityDbContext : IDbContext
{
    IQueryable<User> Users { get; }
}