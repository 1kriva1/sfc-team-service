using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Entities.Metadata;
public class MetadataType : EnumEntity<MetadataTypeEnum>
{
    public MetadataType() : base() { }

    public MetadataType(MetadataTypeEnum enumType) : base(enumType) { }
}