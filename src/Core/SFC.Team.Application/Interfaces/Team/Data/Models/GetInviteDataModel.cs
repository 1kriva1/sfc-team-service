using SFC.Team.Domain.Entities.Team.Data;

namespace SFC.Team.Application.Interfaces.Team.Data.Models;
public record GetInviteDataModel
{
    public IEnumerable<TeamPlayerStatus> TeamPlayerStatuses { get; init; } = [];
}