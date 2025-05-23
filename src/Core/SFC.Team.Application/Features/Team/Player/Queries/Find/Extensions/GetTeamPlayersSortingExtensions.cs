using System.Linq.Expressions;

using SFC.Team.Application.Common.Dto.Player.Filters;
using SFC.Team.Application.Features.Common.Dto.Common;
using SFC.Team.Application.Features.Common.Extensions;
using SFC.Team.Application.Features.Common.Models.Sorting;
using SFC.Team.Application.Features.Team.Player.Queries.Find.Dto.Filters;
using SFC.Team.Domain.Entities.Player;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Features.Team.Player.Queries.Find.Extensions;
public static class GetTeamPlayersSortingExtensions
{
    public static IEnumerable<Sorting<TeamPlayer, dynamic>> BuildTeamPlayerSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting(BuildTeamSortingExpression);

    private static Expression<Func<TeamPlayer, dynamic>>? BuildTeamSortingExpression(string name)
    {
        return name switch
        {
            $"{nameof(GetTeamPlayersFilterDto.TeamPlayer)}.{nameof(GetTeamPlayersTeamPlayerFilterDto.Statuses)}" => p => p.StatusId,
            $"{nameof(GetTeamPlayersFilterDto.Player)}.{nameof(PlayerGeneralProfile.FirstName)}" => p => p.Player.GeneralProfile.FirstName,
            $"{nameof(GetTeamPlayersFilterDto.Player)}.{nameof(PlayerGeneralProfile.LastName)}" => p => p.Player.GeneralProfile.LastName,
            $"{nameof(GetTeamPlayersFilterDto.Player)}.{nameof(PlayerFootballProfile.PhysicalCondition)}" => p => p.Player.FootballProfile.PhysicalCondition!,
            $"{nameof(GetTeamPlayersFilterDto.Player)}.{nameof(PlayerFootballProfile.Height)}" => p => p.Player.FootballProfile.Height!,
            $"{nameof(GetTeamPlayersFilterDto.Player)}.{nameof(PlayerFootballProfile.Weight)}" => p => p.Player.FootballProfile.Weight!,
            $"{nameof(GetTeamPlayersFilterDto.Player)}.{nameof(PlayerStatsFilterDto.Raiting)}" => p => p.Player.Stats.Sum(m => m.Value),
            _ => p => p.StatusId
        };
    }
}