using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;

namespace SFC.Team.Api.Infrastructure.Models.Team.General.Find.Filters;

/// <summary>
/// Get teams filter model.
/// </summary>
public class GetTeamsFilterModel : IMapTo<GetTeamsFilterDto>
{
    /// <summary>
    /// Statuses of team.
    /// </summary>
    public IEnumerable<int> Statuses { get; set; } = default!;

    /// <summary>
    /// Profile filter model.
    /// </summary>
    public GetTeamsProfileFilterModel? Profile { get; set; }
}