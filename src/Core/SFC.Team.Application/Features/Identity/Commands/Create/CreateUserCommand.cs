using SFC.Team.Application.Common.Dto.Identity;
using SFC.Team.Application.Common.Enums;

namespace SFC.Team.Application.Features.Identity.Commands.Create;
public class CreateUserCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateUser; }

    public UserDto User { get; set; } = null!;
}