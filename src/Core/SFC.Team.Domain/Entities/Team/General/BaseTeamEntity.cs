using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Entities.Team.General;
public abstract class BaseTeamEntity : BaseEntity<long>
{
    public TeamEntity Team { get; set; } = null!;
}