using System.ComponentModel;

namespace SFC.Team.Domain.Enums.Metadata;
public enum MetadataState
{
    [Description("Not Required")]
    NotRequired,
    Required,
    Done
}