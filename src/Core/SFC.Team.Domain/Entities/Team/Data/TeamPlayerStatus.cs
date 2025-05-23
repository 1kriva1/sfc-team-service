using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Entities.Team.Data;
public class TeamPlayerStatus : EnumDataEntity<TeamPlayerStatusEnum>
{
    public TeamPlayerStatus() : base() { }

    public TeamPlayerStatus(TeamPlayerStatusEnum enumType) : base(enumType) { }
}