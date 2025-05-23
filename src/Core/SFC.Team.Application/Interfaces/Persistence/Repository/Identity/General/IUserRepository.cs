using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Application.Interfaces.Persistence.Repository.Common;
using SFC.Team.Domain.Entities.Identity;

namespace SFC.Team.Application.Interfaces.Persistence.Repository.Identity.General;
public interface IUserRepository : IRepository<User, IIdentityDbContext, Guid>
{
    Task<User[]> AddRangeIfNotExistsAsync(params User[] entities);
}