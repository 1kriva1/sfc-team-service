using SFC.Team.Messages.Models.Data;

namespace SFC.Team.Messages.Commands.Request.Data;
public record InitializeData
{
    public IEnumerable<DataValue> RequestStatuses { get; init; } = [];
}