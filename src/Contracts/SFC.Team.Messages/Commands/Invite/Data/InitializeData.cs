using SFC.Team.Messages.Models.Data;

namespace SFC.Team.Messages.Commands.Invite.Data;
public record InitializeData
{
    public IEnumerable<DataValue> InviteStatuses { get; init; } = [];
}