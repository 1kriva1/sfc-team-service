using SFC.Team.Application.Common.Dto.Common;

namespace SFC.Team.Application.Common.Dto.Player.Filters;
public class PlayerFilterDto : ExcludeFilterDto
{
    public PlayerProfileFilterDto Profile { get; set; } = default!;

    public PlayerStatsFilterDto Stats { get; set; } = default!;
}