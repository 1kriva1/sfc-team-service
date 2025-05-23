using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Find.Filters;

/// <summary>
/// Get teams **profile filter** model.
/// </summary>
public class GetTeamsProfileFilterModel : IMapTo<GetTeamsProfileFilterDto>
{
    /// <summary>
    /// General profile.
    /// </summary>
    public GetTeamsGeneralProfileFilterModel? General { get; set; }

    /// <summary>
    /// Financial profile.
    /// </summary>
    public GetTeamsFinancialProfileFilterModel? Financial { get; set; }

    /// <summary>
    /// Inventary profile.
    /// </summary>
    public GetTeamsInventaryProfileFilterModel? Inventary { get; set; }
}