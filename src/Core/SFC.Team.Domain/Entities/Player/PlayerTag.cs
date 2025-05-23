using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Entities.Player;
public class PlayerTag : BasePlayerEntity
{
    public string Value { get; set; } = null!;
}