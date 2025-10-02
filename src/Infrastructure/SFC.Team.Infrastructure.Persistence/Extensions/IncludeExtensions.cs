using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Infrastructure.Persistence.Extensions;
public static class IncludeExtensions
{
    #region Player

    public static IQueryable<PlayerEntity> IncludePlayer(this IQueryable<PlayerEntity> players)
    {
        IQueryable<PlayerEntity> result = players
                    .Include(p => p.GeneralProfile)
                    .Include(p => p.FootballProfile)
                    .Include(p => p.Availability)
                    .Include(p => p.Availability.Days)
                    .Include(p => p.Points)
                    .Include(p => p.Tags)
                    .Include(p => p.Stats)
                    .Include(p => p.Photo);

        return result;
    }

    #endregion Player

    #region Team

    public static IQueryable<TeamEntity> IncludeTeam(this IQueryable<TeamEntity> teams)
    {
        IQueryable<TeamEntity> result = teams
                    .Include(p => p.GeneralProfile)
                    .Include(p => p.InventaryProfile)
                    .Include(p => p.FinancialProfile)
                    .Include(p => p.Shirts)
                    .Include(p => p.Availability)
                    .Include(p => p.Tags)
                    .Include(p => p.Logo);

        return result;
    }

    public static IQueryable<TeamEntity> IncludeTeamThanIncludePlayers(this IQueryable<TeamEntity> teams)
    {
        IQueryable<TeamEntity> result = teams
                    .IncludeTeam()
                    .Include(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.GeneralProfile)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.FootballProfile)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability.Days)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Points)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Tags)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Stats)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Photo);

        return result;
    }

    public static IQueryable<TeamPlayer> ThanIncludePlayer(this IQueryable<TeamPlayer> teamPlayers)
    {
        IQueryable<TeamPlayer> result = teamPlayers
                      .Include(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Player).ThenInclude(p => p.Photo);

        return result;
    }

    #endregion Team
}