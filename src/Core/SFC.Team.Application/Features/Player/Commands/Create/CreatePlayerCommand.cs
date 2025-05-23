using SFC.Team.Application.Common.Dto.Player.General;
using SFC.Team.Application.Common.Enums;

namespace SFC.Team.Application.Features.Player.Commands.Create;
public class CreatePlayerCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreatePlayer; }

    public PlayerDto Player { get; set; } = null!;
}