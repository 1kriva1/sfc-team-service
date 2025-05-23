using SFC.Team.Application.Interfaces.Persistence.Repository.Identity.General;
using SFC.Team.Domain.Entities.Identity;
using SFC.Team.Infrastructure.Persistence.Contexts;
using SFC.Team.Infrastructure.Persistence.Extensions;
using SFC.Team.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Identity;
public class UserRepository(IdentityDbContext context)
        : Repository<User, IdentityDbContext, Guid>(context), IUserRepository
{
    public async Task<User[]> AddRangeIfNotExistsAsync(params User[] entities)
    {
        await Context.Set<User>().AddRangeIfNotExistsAsync<User, Guid>(entities).ConfigureAwait(false);

        await Context.SaveChangesAsync().ConfigureAwait(false);

        return entities;
    }
}