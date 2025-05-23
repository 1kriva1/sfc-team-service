using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Entities.Data;
public class StatType : EnumDataEntity<StatTypeEnum>
{
    public StatType() : base() { }

    public StatType(StatTypeEnum enumType) : base(enumType) { }

    public StatCategoryEnum CategoryId { get; set; }

    public StatSkillEnum SkillId { get; set; }
}