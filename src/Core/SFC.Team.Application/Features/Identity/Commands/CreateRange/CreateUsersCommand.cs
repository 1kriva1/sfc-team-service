using SFC.Team.Application.Common.Dto.Identity;
using SFC.Team.Application.Common.Enums;

namespace SFC.Team.Application.Features.Identity.Commands.CreateRange;
public class CreateUsersCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateUsers; }

    public IEnumerable<UserDto> Users { get; set; } = null!;
}