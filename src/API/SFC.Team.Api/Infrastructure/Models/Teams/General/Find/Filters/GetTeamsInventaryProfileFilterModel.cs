using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;

namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Find.Filters;

/// <summary>
/// Get teams **inventary profile filter** model.
/// </summary>
public class GetTeamsInventaryProfileFilterModel : IMapTo<GetTeamsInventaryProfileFilterDto>
{
    /// <summary>
    /// Team's **shirts**.
    /// </summary>
    public IEnumerable<int> Shirts { get; set; } = [];
}