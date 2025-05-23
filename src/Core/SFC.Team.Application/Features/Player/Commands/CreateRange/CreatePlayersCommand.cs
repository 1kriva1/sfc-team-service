using SFC.Team.Application.Common.Dto.Player.General;
using SFC.Team.Application.Common.Enums;

namespace SFC.Team.Application.Features.Player.Commands.CreateRange;
public class CreatePlayersCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreatePlayers; }

    public IEnumerable<PlayerDto> Players { get; set; } = null!;
}