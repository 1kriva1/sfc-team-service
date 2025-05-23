using SFC.Team.Application.Features.Team.Data.Queries.Common.Dto;

namespace SFC.Team.Application.Features.Team.Data.Queries.GetAll;

public record GetAllTeamDataViewModel
{
    public IEnumerable<DataValueDto> TeamPlayerStatuses { get; init; } = [];
}