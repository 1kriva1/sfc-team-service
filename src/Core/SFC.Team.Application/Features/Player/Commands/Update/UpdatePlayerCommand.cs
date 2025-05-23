using SFC.Team.Application.Common.Dto.Player.General;
using SFC.Team.Application.Common.Enums;

namespace SFC.Team.Application.Features.Player.Commands.Update;
public class UpdatePlayerCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.UpdatePlayer; }

    public PlayerDto Player { get; set; } = null!;
}