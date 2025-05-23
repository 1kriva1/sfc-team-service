using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Entities.Data;
public class GameStyle : EnumDataEntity<GameStyleEnum>
{
    public GameStyle() : base() { }

    public GameStyle(GameStyleEnum enumType) : base(enumType) { }
}