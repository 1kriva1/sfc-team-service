using SFC.Team.Domain.Entities.Team.Data;
using SFC.Team.Domain.Entities.Team.General;
using SFC.Team.Domain.Entities.Team.Player;

namespace SFC.Team.Application.Interfaces.Persistence.Context;
public interface ITeamDbContext : IDbContext
{
    #region General

    IQueryable<TeamEntity> Teams { get; }

    IQueryable<TeamGeneralProfile> GeneralProfiles { get; }

    IQueryable<TeamFinancialProfile> FinancialProfiles { get; }

    IQueryable<TeamAvailability> Availability { get; }

    IQueryable<TeamTag> Tags { get; }

    IQueryable<TeamShirt> Shirts { get; }

    IQueryable<TeamLogo> Logos { get; }

    #endregion General

    #region Player

    IQueryable<TeamPlayer> TeamPlayers { get; }

    #endregion Player

    #region Data

    IQueryable<TeamPlayerStatus> TeamPlayerStatuses { get; }

    #endregion Data
}