using SFC.Team.Application.Common.Dto.Identity;

namespace SFC.Team.Application.Interfaces.Identity;
public interface IIdentityService
{
    Task<UserDto?> GetUserAsync(Guid id, CancellationToken cancellationToken = default);
}