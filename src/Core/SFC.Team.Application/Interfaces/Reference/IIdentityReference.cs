using SFC.Team.Application.Common.Dto.Identity;
using SFC.Team.Domain.Entities.Identity;

namespace SFC.Team.Application.Interfaces.Reference;
public interface IIdentityReference : IReference<User, Guid, UserDto> { }