using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Entities.Player;
public abstract class BasePlayerEntity : BaseEntity<long>
{
    public Player Player { get; set; } = null!;
}