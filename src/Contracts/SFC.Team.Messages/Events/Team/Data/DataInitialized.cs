using SFC.Team.Messages.Models.Data;

namespace SFC.Team.Messages.Events.Team.Data;
public record DataInitialized
{
    public IEnumerable<DataValue> TeamPlayerStatuses { get; init; } = [];
}