using SFC.Team.Application.Features.Common.Dto.Common;

namespace SFC.Team.Application.Common.Dto.Player.Filters;
public class PlayerStatsFilterDto
{
    public RangeLimitDto<short?> Total { get; set; } = default!;

    public PlayerStatsBySkillRangeLimitFilterDto Physical { get; set; } = default!;

    public PlayerStatsBySkillRangeLimitFilterDto Mental { get; set; } = default!;

    public PlayerStatsBySkillRangeLimitFilterDto Skill { get; set; } = default!;

    public int? Raiting { get; set; }
}