using SFC.Team.Domain.Common;
using SFC.Team.Domain.Common.Interfaces;
using SFC.Team.Domain.Entities.Team;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Domain.Entities.Player;
public class Player : BaseAuditableReferenceEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }

    public PlayerGeneralProfile GeneralProfile { get; set; } = null!;

    public PlayerFootballProfile FootballProfile { get; set; } = null!;

    public PlayerAvailability Availability { get; set; } = null!;

    public PlayerStatPoints Points { get; set; } = null!;

    public PlayerPhoto Photo { get; set; } = null!;

    public ICollection<PlayerTag> Tags { get; } = [];

    public ICollection<PlayerStat> Stats { get; } = [];
}