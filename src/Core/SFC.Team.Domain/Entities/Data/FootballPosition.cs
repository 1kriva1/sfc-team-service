using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Entities.Data;
public class FootballPosition : EnumDataEntity<FootballPositionEnum>
{
    public FootballPosition() : base() { }

    public FootballPosition(FootballPositionEnum enumType) : base(enumType) { }
}