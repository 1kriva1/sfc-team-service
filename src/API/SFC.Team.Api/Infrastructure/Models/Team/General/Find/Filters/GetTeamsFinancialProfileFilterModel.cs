using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;

namespace SFC.Team.Api.Infrastructure.Models.Team.General.Find.Filters;

/// <summary>
/// Get teams **financial profile filter** model.
/// </summary>
public class GetTeamsFinancialProfileFilterModel : IMapTo<GetTeamsFinancialProfileFilterDto>
{
    /// <summary>
    /// Describe if team can **pay** for football matches and other stuff.
    /// </summary>
    public bool? FreePlay { get; set; }
}