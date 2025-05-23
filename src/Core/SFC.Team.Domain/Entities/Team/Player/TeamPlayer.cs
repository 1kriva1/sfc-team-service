using SFC.Team.Domain.Common;
using SFC.Team.Domain.Common.Interfaces;

namespace SFC.Team.Domain.Entities.Team.Player;
public class TeamPlayer : BaseAuditableEntity<long>, IPlayerEntity, IUserEntity
{
    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public Guid UserId { get; set; }

    public PlayerEntity Player { get; set; } = default!;

    public TeamPlayerStatusEnum StatusId { get; set; }
}