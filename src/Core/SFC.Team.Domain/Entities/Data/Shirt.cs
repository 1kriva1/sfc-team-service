using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Entities.Data;
public class Shirt : EnumDataEntity<ShirtEnum>
{
    public Shirt() : base() { }

    public Shirt(ShirtEnum enumType) : base(enumType) { }
}