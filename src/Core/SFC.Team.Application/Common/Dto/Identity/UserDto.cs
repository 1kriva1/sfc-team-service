using SFC.Team.Application.Common.Dto.Common;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Domain.Entities.Identity;

namespace SFC.Team.Application.Common.Dto.Identity;
public class UserDto : AuditableDto, IMapTo<User>
{
    public Guid Id { get; set; }
}