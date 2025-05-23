using SFC.Team.Application.Features.Common.Dto.Common;

namespace SFC.Team.Application.Common.Dto.Player.Filters;
public class PlayerStatsBySkillRangeLimitFilterDto : RangeLimitDto<short?>
{
    public int Skill { get; set; }
}