using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Entities.Team.Data;
public class TeamStatus : EnumDataEntity<TeamStatusEnum>
{
    public TeamStatus() : base() { }

    public TeamStatus(TeamStatusEnum enumType) : base(enumType) { }
}