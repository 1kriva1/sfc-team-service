using SFC.Team.Messages.Models.Common;

namespace SFC.Team.Messages.Models.Team.Player;
public class TeamPlayer : Auditable
{
    public long Id { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public int StatusId { get; set; }

    public Guid UserId { get; set; }
}