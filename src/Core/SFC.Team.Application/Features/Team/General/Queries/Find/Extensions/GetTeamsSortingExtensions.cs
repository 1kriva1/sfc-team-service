using System.Linq.Expressions;

using SFC.Team.Application.Features.Common.Dto.Common;
using SFC.Team.Application.Features.Common.Extensions;
using SFC.Team.Application.Features.Common.Models.Sorting;
using SFC.Team.Domain.Entities.Team.General;

namespace SFC.Team.Application.Features.Team.General.Queries.Find.Extensions;
public static class GetTeamsSortingExtensions
{
    public static IEnumerable<Sorting<TeamEntity, dynamic>> BuildTeamSearchSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting<TeamEntity>(BuildExpression);

    private static Expression<Func<TeamEntity, dynamic>>? BuildExpression(string name)
    {
        return name switch
        {
            nameof(TeamGeneralProfile.Name) => p => p.GeneralProfile.Name,
            nameof(TeamGeneralProfile.City) => p => p.GeneralProfile.City,
            _ => null
        };
    }
}