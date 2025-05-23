using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Find.Filters;

/// <summary>
/// Get teams filter model.
/// </summary>
public class GetTeamsFilterModel : IMapTo<GetTeamsFilterDto>
{
    /// <summary>
    /// Profile filter model.
    /// </summary>
    public GetTeamsProfileFilterModel? Profile { get; set; }
}